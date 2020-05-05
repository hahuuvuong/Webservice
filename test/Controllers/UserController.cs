using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using testAPIDataAccess;

namespace test.Controllers
{
    public class UserController : ApiController
    {
        /// <summary>
        /// Trả về tất cả user trong database
        /// </summary>
        [HttpGet]
        public IEnumerable<User> getAllUser()
        {
            using (STUDY_SHOPEntities entity = new STUDY_SHOPEntities())
            {
                return entity.Users.ToList();
            }
        }
        /// <summary>
        /// Trả về user bằng email
        /// </summary>
        [HttpGet]
        public HttpResponseMessage getUserByEmail(String email)
        {
            try
            {
                using (STUDY_SHOPEntities dbContext = new STUDY_SHOPEntities())
                {
                    var entity = dbContext.Users.FirstOrDefault(e => e.Email == email);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Không thể tim thấy user với email = " + email.ToString());
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.ToString());
            }
        }
        /// <summary>
        /// Post thêm mới một user
        /// </summary>
        [HttpPost]
        public void Post([FromBody] User user)
        {
            using (STUDY_SHOPEntities dbContext = new STUDY_SHOPEntities())
            {
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
            }
        }
    }
}
