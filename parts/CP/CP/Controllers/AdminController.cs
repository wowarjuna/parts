using CP.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using CP.Models;

namespace CP.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;


        public AdminController()
        {
        }

        public AdminController(ApplicationUserManager userManager, ApplicationRoleManager roleManager)
        {
            UserManager = userManager;
            RoleManager = roleManager;
            
        }

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

        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }

        // GET: Admin
        [Authorize(Roles="admin")]
        public ActionResult Accounts()
        {
            using (var ctx = new CPDataContext())
            {
                ViewBag.Stores = (from x in ctx.Stores
                                  select new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
                ((List<SelectListItem>)ViewBag.Stores).Insert(0, new SelectListItem { Value = "0", Text = "- Select -" });

                ViewBag.Roles = (from x in RoleManager.Roles
                                 select new SelectListItem { Text = x.Name, Value = x.Name.ToString() }).ToList();
                ((List<SelectListItem>)ViewBag.Roles).Insert(0, new SelectListItem { Value = "0", Text = "- Select -" });

                return View();
            }
        }


        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Accounts(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, 
                    Email = string.Format("{0}@wow.com", model.Email.Split(new char[] { '@'})[0]), StoreId = (int)model.StoreId };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var roleTask = await UserManager.AddToRoleAsync(user.Id, model.Role);
                }
                
            }
                     
            return RedirectToAction("Accounts");
        }
    }
}