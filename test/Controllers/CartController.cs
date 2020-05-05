using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using testAPIDataAccess;

namespace test.Controllers
{
    public class CartController : ApiController
    {
        /// <summary>
        /// Trả về tất cả cart trong database
        /// </summary>
        [HttpGet]
        public IEnumerable<Cart> getAllCart()
        {
            using (STUDY_SHOPEntities entity = new STUDY_SHOPEntities())
            {
                return entity.Carts.ToList();
            }
        }
        /// <summary>
        /// Trả về số lượng cart của user và theo tình trạng isPaid
        /// </summary>
        [HttpGet]
        public int getSoluongOfProductUserCartAndIsPaid(int userID1, int isPaid)
        {
            using (STUDY_SHOPEntities entity = new STUDY_SHOPEntities())
            {
                return entity.Carts.Where(x => x.UserId == userID1 && x.IsPaid == isPaid).Count();
            }
        }
        /// <summary>
        /// Trả về số lượng cart của user và theo tình trạng isPaid
        /// </summary>
        [HttpGet]
        public IEnumerable<Cart> getCartByCartID(int cartID)
        {
            using (STUDY_SHOPEntities entity = new STUDY_SHOPEntities())
            {
                return entity.Carts.Where(x => x.Id == cartID ).ToList();
            }
        }
        /// <summary>
        /// Trả về tất cả cart của một user
        /// </summary>
        [HttpGet]
        public IEnumerable<Cart> getAllProductUserCartd(int userID3)
        {
            using (STUDY_SHOPEntities entity = new STUDY_SHOPEntities())
            {
                return entity.Carts.Where(x => x.UserId == userID3 ).ToList();
            }
        }
        /// <summary>
        /// Trả về số lượng cart của user
        /// </summary>
        [HttpGet]
        public int getAmountOfProductUserCart(int userID)
        {
            using (STUDY_SHOPEntities entity = new STUDY_SHOPEntities())
            {
                return entity.Carts.Where(x => x.UserId == userID).Count();
            }
        }
        
        /// <summary>
        /// Trả về trả về số lượng cart của user và theo tình trạng isPaid, chỗ này hình như không cân thiết
        /// </summary>
        [HttpGet]
        public List<Cart> getAllProductOfUserCartAndisPaid(int userID2, int ispaid)
        {
            using (STUDY_SHOPEntities entity = new STUDY_SHOPEntities())
            {
                return entity.Carts.Where(x => x.UserId == userID2 && x.IsPaid == ispaid).ToList();
            }
        }
        /// <summary>
        /// put thay đổi trạng thái isPaid 
        /// </summary>
        [HttpPut]
        public HttpResponseMessage PutChangeIsPaidCart(int idCart, int isPaid)
        {
            try
            {
                using (STUDY_SHOPEntities dbContext = new STUDY_SHOPEntities())
                {
                    var entity = dbContext.Carts.FirstOrDefault(e => e.Id == idCart);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Không thể tim thấy cartitem với id = " + idCart.ToString());
                    }
                    else
                    {
                        entity.IsPaid = isPaid;
                        dbContext.SaveChanges();
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
        /// Post thêm mới một cart
        /// </summary>
        [HttpPost]
        public void Post([FromBody] Cart cart)
        {
            using (STUDY_SHOPEntities dbContext = new STUDY_SHOPEntities())
            {
                dbContext.Carts.Add(cart);
                dbContext.SaveChanges();
            }
        }
    }
}
