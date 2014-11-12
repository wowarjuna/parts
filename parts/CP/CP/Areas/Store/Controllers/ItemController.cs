using CP.Data;
using CP.Data.Models;
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

        public ActionResult Edit(int Id)
        {
            Item item;

            using (var ctx = new CPDataContext())
            {
                item = ctx.Items.FirstOrDefault(x => x.Id.Equals(Id));

                ViewBag.Brands = (from x in ctx.Brands
                                  select new SelectListItem { Text = x.Name, 
                                      Value = x.Id.ToString(), 
                                      Selected = x.Id.Equals(item.BrandId) ? true : false }).ToList();
                ((List<SelectListItem>)ViewBag.Brands).Insert(0, new SelectListItem { Value = "0", Text = "- Select -" });

                ViewBag.Models = (from x in ctx.Models
                                  select new SelectListItem
                                  {
                                      Text = x.Name,
                                      Value = x.Id.ToString(),
                                      Selected = x.Id.Equals(item.ModelId) ? true : false
                                  }).ToList();
                ((List<SelectListItem>)ViewBag.Models).Insert(0, new SelectListItem { Value = "0", Text = "- Select -" });
                

                ViewBag.Categories = (from x in ctx.Categories
                                      select new SelectListItem { Text = x.Name, 
                                          Value = x.Id.ToString(),
                                      Selected = x.Id.Equals(item.CategoryId) ? true : false }).ToList();
                ((List<SelectListItem>)ViewBag.Categories).Insert(0, new SelectListItem { Value = "0", Text = "- Select -" });

                return View(item);
            }
        }

        public ActionResult Sell()
        {
            return View();
        }
    }
}