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
        /// Trả về tất cả product trong giỏ hàng của user nào đó theo tình trạng
        /// </summary>
        [HttpGet]
        public IEnumerable<testAPIDataAccess.returnListCartOfUser_Result> getListCartOfUser(int userID,int isPaid)
        {
            using (STUDY_SHOPEntities entity = new STUDY_SHOPEntities())
            {
                return entity.returnListCartOfUser(userID, isPaid).ToList();
            }
        }
        /// <summary>
        /// Trả về cartitem bởi ID
        /// </summary>
        [HttpGet]
        public List<CartItem> getCartitem(int ID)
        {
            using (STUDY_SHOPEntities entity = new STUDY_SHOPEntities())
            {
                return entity.CartItems.Where(x => x.Id == ID ).ToList();
            }
        }
        /// <summary>
        /// Trả về cartitem bởi cartID (thông qua bảng carts)
        /// </summary>
        [HttpGet]
        public List<CartItem> getCartitemByCart(int cartID)
        {
            using (STUDY_SHOPEntities entity = new STUDY_SHOPEntities())
            {
                return entity.CartItems.Where(x => x.Cart.Id == cartID).ToList();
            }
        }
        /// <summary>
        /// put thay đổi số lượng quantity lên 1 trong cartitem
        /// </summary>
        [HttpPut]
        public HttpResponseMessage PutIncreaseCartItem(int idCartItem)
        {
            try
            {
                using (STUDY_SHOPEntities dbContext = new STUDY_SHOPEntities())
                {
                    var entity = dbContext.CartItems.FirstOrDefault(e => e.Id == idCartItem);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Không thể tim thấy cartitem với id = " + idCartItem.ToString());
                    }
                    else
                    {
                        entity.Quantity = entity.Quantity + 1;
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
        /// Post thêm mới một product vào cartitem của user { "Quantity": 2,"UnitPrice": 1,"ProId": 22,"CartId": 1}
        /// </summary>
        [HttpPost]
        public void Post([FromBody] CartItem cartItem)
        {
            using (STUDY_SHOPEntities dbContext = new STUDY_SHOPEntities())
            {
                dbContext.CartItems.Add(cartItem);
                dbContext.SaveChanges();
            }
        }
        /// <summary>
        /// delete xóa một product ra khỏi giỏ hàng của user
        /// </summary>
        [HttpDelete]
        public HttpResponseMessage DeleteByCartitemID(int idCartitem)
        {
            try
            {
                using (STUDY_SHOPEntities dbContext = new STUDY_SHOPEntities())
                {
                    var entity = dbContext.CartItems.FirstOrDefault(e => e.CartId == idCartitem);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Không thể tim thấy cartitem với id = " + idCartitem.ToString());
                    }
                    else
                    {
                        dbContext.CartItems.Remove(entity);
                        dbContext.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, "Xóa thành công!");
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.ToString());
            }
        }
        /// <summary>
        /// delete xóa một product ra khỏi giỏ hàng của user bằng proid and userid
        /// </summary>
        [HttpDelete]
        public HttpResponseMessage DeleteByUserIDAndProID(int proID,int userID)
        {
            try
            {
                using (STUDY_SHOPEntities dbContext = new STUDY_SHOPEntities())
                {
                    var entity = dbContext.CartItems.FirstOrDefault(e => e.ProId == proID && e.Cart.UserId == userID);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Không thể tim thấy cartitem với id = " + proID.ToString());
                    }
                    else
                    {
                        dbContext.CartItems.Remove(entity);
                        dbContext.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, "Xóa thành công!");
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.ToString());
            }
        }
        /// <summary>
        /// put thay đổi số lượng quantity lên 1 trong cartitem bằng proid và userid
        /// </summary>
        [HttpPut]
        public HttpResponseMessage PutIncreaseCartItembyProidAndUserid(int proID,int userID,int state)
        {
            try
            {
                using (STUDY_SHOPEntities dbContext = new STUDY_SHOPEntities())
                {
                    var entity = dbContext.CartItems.FirstOrDefault(e => e.Cart.UserId == userID && e.ProId == proID && e.Cart.IsPaid == state);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Không thể tim thấy cartitem với id = " + proID.ToString());
                    }
                    else
                    {
                        entity.Quantity = entity.Quantity + 1;
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
        /// put thay đổi số lượng quantity xuống 1 đơn vị trong cartitem bằng proid và userid
        /// </summary>
        [HttpPut]
        public HttpResponseMessage PutDecreaseCartItembyProidAndUserid(int proID, int userID, int state)
        {
            try
            {
                using (STUDY_SHOPEntities dbContext = new STUDY_SHOPEntities())
                {
                    var entity = dbContext.CartItems.FirstOrDefault(e => e.Cart.UserId == userID && e.ProId == proID && e.Cart.IsPaid == state);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Không thể tim thấy cartitem với id = " + proID.ToString());
                    }
                    else
                    {
                        if(entity.Quantity > 1){
                            entity.Quantity = entity.Quantity - 1;
                            dbContext.SaveChanges();
                            return Request.CreateResponse(HttpStatusCode.OK, entity);
                        }
                        else
                            return Request.CreateResponse(HttpStatusCode.Conflict, entity);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.ToString());
            }
        }
    }
}
