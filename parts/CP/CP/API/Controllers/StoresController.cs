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
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }

    public class StoresController : ApiController
    {
        Product[] products = new Product[] 
        { 
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 }, 
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M }, 
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M } 
        };

        public IEnumerable<Store> GetAllStores()
        {
            IEnumerable<Store> result;
            using (var ctx = new CPDataContext())
            {
                result = ctx.Stores.ToList();               
            }

            return result;
        }

        public IHttpActionResult GetStore(int id)
        {
            using (var ctx = new CPDataContext())
            {
                var store = ctx.Stores.FirstOrDefault(s => s.Id.Equals(id));
                if (store == null)
                {
                    return NotFound();
                }
                return Ok(store);
                
            }
              
            
        }

        public HttpResponseMessage PostStore(Store store)
        {
            using (var ctx = new CPDataContext())
            {
                ctx.Stores.Attach(store);
                ctx.Entry(store).State = System.Data.Entity.EntityState.Modified;
                try
                {
                    ctx.SaveChanges();
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                catch(Exception)
                {
                    throw new HttpResponseException(HttpStatusCode.InternalServerError);
                }

            }
        }
    }
}
