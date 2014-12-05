using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CP.Areas.Store.Controllers
{
    public class StocklotController : Controller
    {
        // GET: Store/Stocklot
        [Authorize(Roles="store")]
        public ActionResult Index()
        {
            return View();
        }
    }
}