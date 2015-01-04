using CP.Data;
using CP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using System.Data.SqlClient;

namespace CP.Areas.Store.Controllers
{
    public class ChartsController : Controller
    {
        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: Store/Charts
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Sales()
        {
            return View();
        }

        public ActionResult Stocklots()
        {
            return View();
        }

        public JsonResult GetStocklotChart(DateTime from, DateTime to)
        {
            var user = UserManager.FindByNameAsync(User.Identity.Name);

            using (var ctx = new CPDataContext())
            {
                var query = ctx.Database.SqlQuery<StocklotChartResponse>("sp_get_stocklot_charts @storeid, @from, @to", 
                    new SqlParameter("@storeid",user.Result.StoreId), 
                    new SqlParameter("@from", from),
                    new SqlParameter("@to", to));

                
                return Json(query.ToList(), JsonRequestBehavior.AllowGet);

            }
        }

        public JsonResult GetSalesChart(DateTime from, DateTime to)
        {
            var user = UserManager.FindByNameAsync(User.Identity.Name);

            using (var ctx = new CPDataContext())
            {
                var query = ctx.Database.SqlQuery<SalesChartResponse>("sp_get_sales_charts @storeid, @from, @to",
                    new SqlParameter("@storeid", user.Result.StoreId),
                    new SqlParameter("@from", from),
                    new SqlParameter("@to", new DateTime(to.Year, to.Month, DateTime.DaysInMonth(to.Year, to.Month))));


                return Json(query.ToList(), JsonRequestBehavior.AllowGet);

            }
        }
    
    }
}