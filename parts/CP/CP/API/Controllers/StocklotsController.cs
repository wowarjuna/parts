using CP.Data;
using CP.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using Microsoft.AspNet.Identity.Owin;

namespace CP.API.Controllers
{
    public class StocklotsController : ApiController
    {
        [Authorize(Roles = "store")]
        [Route("api/stocklots")]
        public IEnumerable<Stocklot> GetAllStocklots()
        {
            ApplicationUserManager userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();

            var user = userManager.FindByNameAsync(User.Identity.Name);

            IEnumerable<Stocklot> result;
            using (var ctx = new CPDataContext())
            {
                result = ctx.Stocklots.Where(x => x.StoreId.Equals(user.Result.StoreId)).ToList();
            }

            return result;
        }

        [Authorize(Roles="store")]
        [HttpPost]
        [Route("api/stocklots/stocklot")]
        public HttpResponseMessage PostStocklot(Stocklot stocklot)
        {
            ApplicationUserManager userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();

            var user = userManager.FindByNameAsync(User.Identity.Name);

            using (var ctx = new CPDataContext())
            {
                if (stocklot.Id.Equals(0))
                {
                    stocklot.Created = DateTime.Now;
                    stocklot.Modified = DateTime.Now;
                    stocklot.StoreId = user.Result.StoreId;
                    stocklot.CreatedBy = user.Result.UserName;
                    ctx.Stocklots.Add(stocklot);
                }
                else
                {
                    stocklot.Modified = DateTime.Now;
                    var original = ctx.Stocklots.Find(stocklot.Id);
                    if (original != null)
                    {
                        ctx.Entry(original).CurrentValues.SetValues(stocklot);
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
