using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using testAPIDataAccess;

namespace test.Controllers
{
    public class CartItemController : ApiController
    {
        /// <summary>
        /// Trả về tất cả product trong giỏ hàng của user theo tình trạng
        /// </summary>
        [HttpGet]
        public IEnumerable<testAPIDataAccess.returnListCartOfUser_Result> getListCartOfUser(int userID,int isPaid)
        {
            using (STUDY_SHOPEntities entity = new STUDY_SHOPEntities())
            {
                return entity.returnListCartOfUser(userID, isPaid).ToList();
            }
        }
    }
}
