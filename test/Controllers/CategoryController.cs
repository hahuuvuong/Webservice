using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using testAPIDataAccess;

namespace test.Controllers
{
    public class CategoryController : ApiController
    {
        /// <summary>
        /// Trả về toàn bộ Category
        /// </summary>
        [HttpGet]
        public IEnumerable<Category> getAllProduct()
        {
            STUDY_SHOPEntities db = new STUDY_SHOPEntities();
            List<Category> Listprore = db.Categories.Where(x => x.CateId!= 0 ).ToList();
            List<Category> Listkqre = new List<Category>();
            foreach (Category k in Listprore)
            {
                Category c = new Category();
                c.CateId = k.CateId;
                c.CateImage = k.CateImage;
                c.CateName = k.CateName;
                Listkqre.Add(c);
            }
            return Listkqre.ToList();
        }
    }
}
