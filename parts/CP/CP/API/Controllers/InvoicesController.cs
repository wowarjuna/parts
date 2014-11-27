using CP.Data;
using CP.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace CP.API.Controllers
{
    public class InvoiceSearchRequest
    {
        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public int Limit { get; set; }

        public int Offset { get; set; }

        public void Validate()
        {
        }
       
    }

    public class InvoiceSearchResponse
    {
        public int total { get; set; }

        public IEnumerable<Invoice> rows { get; set; }
    }


    public class InvoiceResponse
    {
        public int InvoiceId { get; set; }
    }

    public class InvoicesController : ApiController
    {
        [Route("api/invoices/find")]
        public InvoiceSearchResponse GetInvoices([FromUri]InvoiceSearchRequest criteria)
        {
            criteria.Validate();

            using (var ctx = new CPDataContext())
            {
                var query = ctx.Invoices.Where(x => x.Created > criteria.Start && x.Created < criteria.End );

                return new InvoiceSearchResponse
                {
                    rows = query.OrderBy(x => x.Created).Skip(criteria.Offset).Take(criteria.Limit).ToList(),
                    total = query.Count()
                };
            }
        }

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
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new ObjectContent<InvoiceResponse>(new InvoiceResponse
                    {
                        InvoiceId = invoice.Id
                    }, new JsonMediaTypeFormatter(), "application/json");
                    return response;
                }
                catch (Exception ex)
                {
                    throw new HttpResponseException(HttpStatusCode.InternalServerError);
                }

            }
            

        }
    }
}
