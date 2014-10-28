using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Security;

namespace AutoPP.Web.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Dashboard()
        {
            //Membership.CreateUser("wowarjuna@hotmail.com", "welcome", "wowarjuna@hotmail.com");
            //Roles.AddUserToRole("wowarjuna@hotmail.com", "admin");
            return View();
        }

        public ActionResult ReportDashboard()
        {
            return View();
        }
    }
}
