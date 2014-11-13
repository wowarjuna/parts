using CP.Data;
using CP.Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace CP.API.Controllers
{
    

    public class ItemSearchRequest
    {

        public string Name { get; set; }

        public int BrandId { get; set; }

        public int CategoryId { get; set; }

        public int ModelId { get; set; }

        public string PartNo { get; set; }

        public int Page { get; set; }

        public int Offset { get; set; }

        public void Validate()
        {
            if (Name == null)
                Name = string.Empty;

            if (PartNo == null)
                PartNo = string.Empty;
        }
    }

    public class ItemSearchResponse
    {
        public int total { get; set; }

        public IEnumerable<Item> rows { get; set; }
    }

   

    public class ItemsController : ApiController
    {
        [Route("api/items/find")]
        public ItemSearchResponse GetItems([FromUri]ItemSearchRequest criteria)
        {
            criteria.Validate();

            using (var ctx = new CPDataContext())
            {
                var query = ctx.Items.Where(x => (criteria.Name.Equals("") || x.Name.Contains(criteria.Name))
                    && (criteria.PartNo.Equals("") || x.PartNo.Contains(criteria.PartNo))
                    && (criteria.BrandId.Equals(0) || x.BrandId.Equals(criteria.BrandId))
                    && (criteria.CategoryId.Equals(0) || x.CategoryId.Equals(criteria.CategoryId))
                    && (criteria.ModelId.Equals(0) || x.ModelId.Equals(criteria.ModelId)));

                return new ItemSearchResponse
                {
                    rows = query.ToList(),
                    total = query.Count()
                };
            }
        }

        public HttpResponseMessage PostItem(Item item)
        {
            using (var ctx = new CPDataContext())
            {
                item.Created = DateTime.Now;
                item.StoreId = 1;
                ctx.Items.Add(item);
                try
                {
                    ctx.SaveChanges();
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                catch (Exception)
                {
                    throw new HttpResponseException(HttpStatusCode.InternalServerError);
                }

            }
        }

        [Route("api/items/updateitem")]
        [HttpPost]
        public HttpResponseMessage PostUpdateItem(Item item)
        {
            using (var ctx = new CPDataContext())
            {
                ctx.Items.Attach(item);
                ctx.Entry(item).State = System.Data.Entity.EntityState.Modified;
                try
                {
                    ctx.SaveChanges();
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                catch (Exception)
                {
                    throw new HttpResponseException(HttpStatusCode.InternalServerError);
                }

            }
        }

        [Route("api/items/updatestoreinfo")]
        [HttpPost]
        public HttpResponseMessage PostUpdateStoreInfo([FromBody]List<Item> items)
        {
            using (var ctx = new CPDataContext())
            {
                return new HttpResponseMessage(HttpStatusCode.OK);               

            }
        }

        
    }
}
