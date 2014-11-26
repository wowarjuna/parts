using CP.Data;
using CP.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CP.Areas.Store.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Store/Invoice
        public ActionResult Index(int id)
        {
            Session["cart"] = null;
           
            var ctx = new CPDataContext();
            Invoice invoice = ctx.Invoices.Include("Items").First(x => x.Id.Equals(id));
            return View(invoice);
            
            
        }
    }
}