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
    public class ModelsController : ApiController
    {
        [Route("api/models/bybrand/{brand}")]
        public IEnumerable<Model> GetAllModelsByBrand(int brand)
        {
            IEnumerable<Model> result;
            using (var ctx = new CPDataContext())
            {
                result = ctx.Models.Where(x => x.BrandId.Equals(brand)).ToList();
            }

            return result;
        }
    }
}
