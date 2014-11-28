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
        public int InvoiceNoInt { get; set; }

        public DateTime? Start { get; set; }

        public DateTime? End { get; set; }

        public string InvoiceNo { get; set; }

        public int Limit { get; set; }

        public int Offset { get; set; }

        public void Validate()
        {
            int _invoice;
            if (!int.TryParse(InvoiceNo, out _invoice))
                InvoiceNoInt = 0;
            else
                InvoiceNoInt = _invoice;

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

    public class InvoiceItem
    {
        public string PartNo { get; set; }
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public int Qty { get; set; }
    }

    public class InvoicesController : ApiController
    {
        [Route("api/invoices/find")]
        public InvoiceSearchResponse GetInvoices([FromUri]InvoiceSearchRequest criteria)
        {
            criteria.Validate();

            using (var ctx = new CPDataContext())
            {
                var query = ctx.Invoices.Where(x => (criteria.InvoiceNoInt.Equals(0) || x.Id.Equals(criteria.InvoiceNoInt))
                || (x.Created > criteria.Start && x.Created < criteria.End));

                return new InvoiceSearchResponse
                {
                    rows = query.OrderBy(x => x.Created).Skip(criteria.Offset).Take(criteria.Limit).ToList(),
                    total = query.Count()
                };
            }
        }

        [Route("api/invoices/{invoiceId}/items")]
        public IEnumerable<InvoiceItem> GetItems(int invoiceId)
        {
            using (var ctx = new CPDataContext())
            {
                var query = ctx.Invoices.Where(x => x.Id.Equals(invoiceId));

                return (from x in ctx.Sales.Where(x => x.InvoiceId.Equals(invoiceId))
                        select new InvoiceItem
                        {
                            PartNo = x.Item.PartNo,
                            Name = x.Item.Name,
                            Qty = x.Qty,
                            UnitPrice = x.UnitPrice

                        }).ToList();
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
