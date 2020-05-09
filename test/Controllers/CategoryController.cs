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
        public IEnumerable<Category> getAllCategory()
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
        /// <summary>
        /// Trả về số lượng trang của từng lọai
        /// </summary>
        [HttpGet]
        public int getAmountOfPageCategory(int idCategory)
        {
            using (STUDY_SHOPEntities entity = new STUDY_SHOPEntities())
            {
                int temp = entity.Products.Where(x => x.Category.CateId == idCategory).Count();
                if (temp == 0)
                    return 0;
                if (temp < 9)
                    return 1;
                else if (temp % 8 == 0)
                    return temp / 8;
                else
                    return (temp / 8 + 1);
            }
        }
    }
}
