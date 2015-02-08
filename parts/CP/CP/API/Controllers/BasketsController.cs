using CP.Data;
using CP.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity.Owin;
using System.Web;

namespace CP.API.Controllers
{
    public class BasketsController : ApiController
    {
        [Authorize(Roles="store")]
        [Route("api/baskets")]
        public IEnumerable<Basket> GetAllBaskets()
        {
            ApplicationUserManager userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();

            var user = userManager.FindByNameAsync(User.Identity.Name);

            IEnumerable<Basket> result;
            using (var ctx = new CPDataContext())
            {
                result = ctx.Baskets.Where(x => x.StoreId.Equals(user.Result.StoreId)).ToList();
            }

            return result;
        }

        [Route("api/baskets/{id}")]
        public Basket GetBasket(int id)
        {
            using (var ctx = new CPDataContext())
            {
                return ctx.Baskets.Find(id);
            }
        }


        [Authorize(Roles="store")]
        [Route("api/baskets/basket")]
        public HttpResponseMessage PostBasket(Basket basket)
        {
            ApplicationUserManager userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();

            var user = userManager.FindByNameAsync(User.Identity.Name);

            using (var ctx = new CPDataContext())
            {
                if (basket.Id.Equals(0))
                {
                    basket.Created = DateTime.Now;
                    basket.StoreId = user.Result.StoreId;
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
                        ctx.Entry(original).Property(x => x.StoreId).IsModified = false;
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
