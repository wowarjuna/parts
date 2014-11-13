using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CP.Areas.Store.Controllers
{
    public class BasketController : Controller
    {
        // GET: Store/Basket
        public ActionResult Index()
        {
            return View();
        }
    }
}