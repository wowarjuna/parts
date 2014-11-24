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
        public ActionResult Index()
        {
            Session["cart"] = null;
            return View();
        }
    }
}