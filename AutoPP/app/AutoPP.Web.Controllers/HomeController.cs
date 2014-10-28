using System.Web.Mvc;
using System.Web.Security;

namespace AutoPP.Web.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            
            //ViewBag.Title = "Test";
            return View();
        }
    }
}
