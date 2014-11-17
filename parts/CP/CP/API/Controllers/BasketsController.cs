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
    public class BasketsController : ApiController
    {
        [Route("api/baskets/{store}")]
        public IEnumerable<Basket> GetAllModelsByBrand(int store)
        {
            IEnumerable<Basket> result;
            using (var ctx = new CPDataContext())
            {
                result = ctx.Baskets.Where(x => x.StoreId.Equals(store)).ToList();
            }

            return result;
        }

        public HttpResponseMessage PostBasket(Basket basket)
        {
            using (var ctx = new CPDataContext())
            {
                if (basket.Id.Equals(0))
                {
                    basket.Created = DateTime.Now;
                    basket.StoreId = 1;
                    ctx.Baskets.Add(basket);
                }
                else
                {
                    basket.Modified = DateTime.Now;
                    var original = ctx.Baskets.Find(basket.Id);
                    if (original != null)
                    {
                        ctx.Entry(original).CurrentValues.SetValues(basket);
                        ctx.Entry(original).Property(x => x.Created).IsModified = false;
                    }
                }

                try
                {
                    ctx.SaveChanges();
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                catch (Exception ex)
                {
                    throw new HttpResponseException(HttpStatusCode.InternalServerError);
                }

            }
        }
    }
}
