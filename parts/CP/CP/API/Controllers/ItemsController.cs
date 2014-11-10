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
    public class ItemSearch
    {
        public string Name { get; set; }

        public int Page { get; set; }

        public int Offset { get; set; }
    }

    public class ItemsController : ApiController
    {
        [Route("api/items/find")]
        public IEnumerable<Item> GetItems([FromUri]ItemSearch criteria)
        {
            using(var ctx = new CPDataContext())
            {
                return ctx.Items.Where(x => (x.Name == "" || x.Name.Contains(criteria.Name))).ToList();
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
