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
        /// Trả về trả về số lượng cart của user
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
        /// Trả về trả về số lượng cart của user và theo tình trạng isPaid
        /// </summary>
        [HttpGet]
        public int getAmountOfProductUserCartAndIsPaid(int userID, int isPaid)
        {
            using (STUDY_SHOPEntities entity = new STUDY_SHOPEntities())
            {
                return entity.Carts.Where(x => x.UserId == userID && x.IsPaid == isPaid).Count();
            }
        }
        /// <summary>
        /// Trả về trả về số lượng cart của user và theo tình trạng isPaid
        /// </summary>
        //[HttpGet]
        //public int getamountofproductusercartandispaid(int userid, int ispaid)
        //{
        //    using (study_shopentities entity = new study_shopentities())
        //    {
        //        return entity.carts.where(x => x. == userid && x.ispaid == ispaid).count();
        //    }
        //}
    }
}
