using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CP.Areas.Store.Controllers
{
    public class StoresController : Controller
    {
        // GET: Store/Stores
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit(int Id)
        {
            return View(Id);
        }

        public ActionResult Contacts()
        {
            return View();
        }
    }
}