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
                    foreach(var item in invoice.Items)
                    {
                        var original = ctx.Items.Find(item.ItemId);
                        original.Qty = original.Qty - item.Qty;
                    }
                    ctx.Invoices.Add(invoice);
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
