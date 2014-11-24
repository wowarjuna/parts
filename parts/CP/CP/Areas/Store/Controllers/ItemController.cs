using CP.Data;
using CP.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
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

                ViewBag.Baskets = (from x in ctx.Baskets
                                   select new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
                ((List<SelectListItem>)ViewBag.Baskets).Insert(0, new SelectListItem { Value = "0", Text = "- Select -" });

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

                ViewBag.Baskets = (from x in ctx.Baskets
                                      select new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
                ((List<SelectListItem>)ViewBag.Baskets).Insert(0, new SelectListItem { Value = "0", Text = "- Select -" });

                return View();
            }
           
        }


        [HttpGet]
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

                ViewBag.Baskets = (from x in ctx.Baskets
                                      select new SelectListItem
                                      {
                                          Text = x.Name,
                                          Value = x.Id.ToString()
                                      }).ToList();
                ((List<SelectListItem>)ViewBag.Baskets).Insert(0, new SelectListItem { Value = "0", Text = "- Select -" });
                if (item.BasketId != null)
                    ((List<SelectListItem>)ViewBag.Baskets).FirstOrDefault(x => x.Value.Equals(((int)item.BasketId).ToString())).Selected = true;

                return View(item);
            }
        }

        public ActionResult Sell()
        {
            if (Session["cart"] != null)
                return View(((List<long>)Session["cart"]).Count);
            else
                return View(0);

        }

        [HttpPost]
        public JsonResult AddToCart(List<long> idList)
        {
            if (Session["cart"] == null)
                Session["cart"] = new List<long>(idList);
            else
                Session["cart"] = ((List<long>)Session["cart"]).Union(idList).ToList();


            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteFromCart(long id)
        {
            IList<Item> items = new List<Item>();
            var cart = Session["cart"] as List<long>;
            using (var ctx = new CPDataContext())
            {
                cart.Remove(id);
               
                if (cart != null)
                    items = ctx.Items.Where(x => cart.Contains(x.Id)).ToList();
                return Json(items, JsonRequestBehavior.AllowGet);
            }
          
        }

        [HttpPost]
        public JsonResult CancelCheckout()
        {
            Session["cart"] = null;
            return Json(new { message = true }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Cart()
        {
            IList<Item> items = new List<Item>();
            using (var ctx = new CPDataContext())
            {
                List<long> cart = Session["cart"] as List<long>;
                if(cart != null)
                    items = ctx.Items.Where(x => cart.Contains(x.Id)).ToList();
                return Json(items, JsonRequestBehavior.AllowGet);
            }
            
        }

        public ActionResult Sales()
        {
            return View();
        }
    }
}