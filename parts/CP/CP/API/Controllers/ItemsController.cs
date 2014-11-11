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
    public class ItemSearchRequest
    {
        
        public string Name { get; set; }

        public int BrandId { get; set; }

        public int Page { get; set; }

        public int Offset { get; set; }

        public void Validate()
        {
            if (Name == null)
                Name = string.Empty;
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

            using(var ctx = new CPDataContext())
            {
                var query = ctx.Items.Where(x => (x.Name == "" || x.Name.Contains(criteria.Name)) 
                    && (x.BrandId == 0 || x.BrandId.Equals(criteria.BrandId)));

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
    }
}
