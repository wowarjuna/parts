using CP.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CP.Areas.Store.Controllers
{
    public class ItemController : Controller
    {
        // GET: Store/Item
        public ActionResult Index()
        {
            using (var ctx = new CPDataContext())
            {
                ViewBag.Brands = (from x in ctx.Brands
                                  select new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
                ((List<SelectListItem>)ViewBag.Brands).Insert(0, new SelectListItem { Value = "0", Text = "- Select -" });

                ViewBag.Categories = (from x in ctx.Categories
                                      select new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
                ((List<SelectListItem>)ViewBag.Categories).Insert(0, new SelectListItem { Value = "0", Text = "- Select -" });

                return View();
            }
        }

        public ActionResult Add()
        {
            using(var ctx = new CPDataContext())
            {
                ViewBag.Brands = (from x in ctx.Brands
                                 select new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
                ((List<SelectListItem>)ViewBag.Brands).Insert(0, new SelectListItem { Value = "0", Text = "- Select -" });

                ViewBag.Categories = (from x in ctx.Categories
                                  select new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
                ((List<SelectListItem>)ViewBag.Categories).Insert(0, new SelectListItem { Value = "0", Text = "- Select -" });

                return View();
            }
           
        }

        public ActionResult Sell()
        {
            return View();
        }
    }
}