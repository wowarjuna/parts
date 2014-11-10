using CP.Data;
using CP.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CP.API.Controllers
{
    public class CategoriesController : ApiController
    {
        [Route("api/categories")]
        public IEnumerable<Category> GetAllModelsByBrand(int brand)
        {
            IEnumerable<Category> result;
            using (var ctx = new CPDataContext())
            {
                result = ctx.Categories.ToList();
            }

            return result;
        }
    }
}
