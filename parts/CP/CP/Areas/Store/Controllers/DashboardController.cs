using CP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;

namespace CP.Areas.Store.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Store/Dashboard
        [Authorize]
        public ActionResult Index()
        {                       
            return View();
        }
    }
}