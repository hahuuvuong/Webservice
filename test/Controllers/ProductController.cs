using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using testAPIDataAccess;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;

namespace test.Controllers
{
    public class ProductController : ApiController
    {
        /// <summary>
        /// Trả về toàn bộ product
        /// </summary>
        [HttpGet]
        public IEnumerable<testAPIDataAccess.returnAllProducts_Result> getAllProduct()
        {
            using (STUDY_SHOPEntities entity = new STUDY_SHOPEntities())
            {
                return entity.returnAllProducts().ToList();
            }
        }
        /// <summary>
        /// Trả về một product với id 
        /// </summary>
        [HttpGet]
        public IHttpActionResult getProductById(int id)
        {
            using (STUDY_SHOPEntities dbContext = new STUDY_SHOPEntities())
            {
                var entity = dbContext.Products.FirstOrDefault(e => e.Id == id);
                if (entity != null)
                {
                    return Ok(entity);
                }
                else
                {
                    return NotFound();
                }
            }
        }
        /// <summary>
        /// Trả về tất cả product theo loại category
        /// </summary>
        [HttpGet]
        public IEnumerable<Product> getAllProductByIdCategory(int idType)
        {
            STUDY_SHOPEntities db = new STUDY_SHOPEntities();
            List<Product> Listprore = db.Products.Where(x => x.CateId == idType).ToList();
            List<Product> Listkqre = new List<Product>();
            foreach (Product k in Listprore)
            {
                Product p = new Product();
                p.Id = k.Id;
                p.Name = k.Name;
                p.Price = k.Price;
                p.Discount = k.Discount;
                p.CateId = k.CateId;
                p.Description = k.Description;
                p.Information = k.Information;
                p.Image = k.Image;
                Listkqre.Add(p);
            }
            return Listkqre.ToList();
        }
        /// <summary>
        /// Trả về số lượng product theo loại category
        /// </summary>
        [HttpGet]
        public int getAmountProductByIdCategory(int idTypeCategory)
        {
            STUDY_SHOPEntities db = new STUDY_SHOPEntities();
            List<Product> Listprore = db.Products.Where(x => x.CateId == idTypeCategory).ToList();
            List<Product> Listkqre = new List<Product>();
            int temp = 0;
            foreach (Product k in Listprore)
            {
                temp++;
            }
            return temp;
        }

    }
}
