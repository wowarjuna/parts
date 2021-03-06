﻿using CP.Data;
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
    [RoutePrefix("api/baskets")]
    public class BasketsController : ApiController
    {
        [Authorize(Roles="store")]
        [Route("")]
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

        [Route("{id}")]
        public Basket GetBasket(int id)
        {
            using (var ctx = new CPDataContext())
            {
                return ctx.Baskets.Find(id);
            }
        }


        [Authorize(Roles="store")]
        [Route("")]
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

        [Authorize(Roles="store")]
        [Route("remove/{Id}")]
        public HttpResponseMessage Remove(int Id)
        {
            ApplicationUserManager userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();

            var user = userManager.FindByNameAsync(User.Identity.Name);

            using (var ctx = new CPDataContext())
            {
                try
                {
                    if (!ctx.Items.Any(x => x.BasketId == Id))
                    {
                        var basket = ctx.Baskets.Single(x => x.Id.Equals(Id));
                        ctx.Baskets.Remove(basket);
                        ctx.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("There are items assigned to this basket. Please remove them first");
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
