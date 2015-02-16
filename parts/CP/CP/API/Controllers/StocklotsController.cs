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
    [RoutePrefix("api/stocklots")]
    public class StocklotsController : ApiController
    {
        [Authorize(Roles = "store")]
        [Route("")]
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

        [Route("{id}")]
        public Stocklot GetStocklot(int id)
        {
            using (var ctx = new CPDataContext())
            {
                return ctx.Stocklots.Find(id);
            }
        }

        [Authorize(Roles="store")]
        [HttpPost]
        [Route("")]
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
                        ctx.Entry(original).Property(x => x.CreatedBy).IsModified = false;
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

        [Authorize(Roles = "store")]
        [Route("remove/{Id}")]
        public HttpResponseMessage Remove(int Id)
        {
            ApplicationUserManager userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();

            var user = userManager.FindByNameAsync(User.Identity.Name);

            using (var ctx = new CPDataContext())
            {
                try
                {
                    if (!ctx.Items.Any(x => x.StocklotId == Id))
                    {
                        var stocklot = ctx.Stocklots.Single(x => x.Id.Equals(Id));
                        ctx.Stocklots.Remove(stocklot);
                        ctx.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("There are items assigned to this stocklot. Please remove them first");
                    }
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.Forbidden, ex);
                }
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
