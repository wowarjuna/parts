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
    
    public class StoresController : ApiController
    {
        
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
