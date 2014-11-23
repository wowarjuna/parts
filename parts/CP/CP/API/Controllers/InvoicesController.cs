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
    public class InvoicesController : ApiController
    {
        public HttpResponseMessage PostInvoice(Invoice invoice)
        {
            using (var ctx = new CPDataContext())
            {
                if (invoice.Id.Equals(0))
                {
                    invoice.Created = DateTime.Now;
                    ctx.Invoices.Add(invoice);
                }
                else
                {
                    invoice.Modified = DateTime.Now;
                    var original = ctx.Invoices.Find(invoice.Id);
                    if (original != null)
                    {
                        ctx.Entry(original).CurrentValues.SetValues(invoice);
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
