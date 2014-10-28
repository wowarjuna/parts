using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Security;
using AutoPP.Core;
using AutoPP.ApplicationServices;

namespace AutoPP.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService UserService)
        {
            _userService = UserService;
        }

        public ActionResult LogOn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(FormCollection data, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(data["username"], data["password"]))
                {
                    if (data["remember-me"] != null)
                        FormsAuthentication.SetAuthCookie(data["username"], true);
                    else
                        FormsAuthentication.SetAuthCookie(data["username"], false);
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        Session["User"] = _userService.GetUser(Membership.GetUser(data["username"]).ProviderUserKey.ToString());
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        Session["User"] = _userService.GetUser(Membership.GetUser(data["username"]).ProviderUserKey.ToString());
                        if (Roles.IsUserInRole(data["username"], "customer"))
                        {
                            return RedirectToAction("Items", "Request");
                        }
                        else if (Roles.IsUserInRole(data["username"], "admin"))
                        {
                            return RedirectToAction("Dashboard", "Admin");
                        }
                        else if (Roles.IsUserInRole(data["username"], "vendor"))
                        {
                            return RedirectToAction("Items", "Item");
                        }
                        else
                        {
                            return RedirectToAction("Index", "Vendor");
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View();
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Search");
        }


        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User customer)
        {
            if (ModelState.IsValid)
            {
                Membership.CreateUser(customer.UserName, customer.Password, customer.UserName);
                Roles.AddUserToRole(customer.UserName, "customer");
                return View("RegisterSuccess");
            }
            return View();
        }
    }
}
