using CP.Data;
using CP.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using System.IO;

namespace CP.Areas.Store.Controllers
{
    public class ItemController : Controller
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

       

        // GET: Store/Item
        [Authorize(Roles = "store")]
        public ActionResult Index()
        {
            var user = UserManager.FindByNameAsync(User.Identity.Name);

            using (var ctx = new CPDataContext())
            {
                ViewBag.Brands = (from x in ctx.Brands
                                  select new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
                ((List<SelectListItem>)ViewBag.Brands).Insert(0, new SelectListItem { Value = "0", Text = "- Select -" });

                ViewBag.Categories = (from x in ctx.Categories
                                      select new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
                ((List<SelectListItem>)ViewBag.Categories).Insert(0, new SelectListItem { Value = "0", Text = "- Select -" });

                ViewBag.Baskets = (from x in ctx.Baskets.Where(x => x.StoreId.Equals(user.Result.StoreId))
                                   select new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
                ((List<SelectListItem>)ViewBag.Baskets).Insert(0, new SelectListItem { Value = "0", Text = "- Select -" });

                ViewBag.Stocklots = (from x in ctx.Stocklots.Where(x => x.StoreId.Equals(user.Result.StoreId))
                                     select new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
                ((List<SelectListItem>)ViewBag.Stocklots).Insert(0, new SelectListItem { Value = "0", Text = "- Select -" });

                return View();
            }
        }

        [Authorize(Roles = "store")]
        public ActionResult Add()
        {
            var user = UserManager.FindByNameAsync(User.Identity.Name);

            using(var ctx = new CPDataContext())
            {
                ViewBag.Brands = (from x in ctx.Brands
                                 select new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
                ((List<SelectListItem>)ViewBag.Brands).Insert(0, new SelectListItem { Value = "0", Text = "- Select -" });

                ViewBag.Categories = (from x in ctx.Categories
                                  select new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
                ((List<SelectListItem>)ViewBag.Categories).Insert(0, new SelectListItem { Value = "0", Text = "- Select -" });

                ViewBag.Baskets = (from x in ctx.Baskets.Where(x => x.StoreId.Equals(user.Result.StoreId))
                                      select new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
                ((List<SelectListItem>)ViewBag.Baskets).Insert(0, new SelectListItem { Value = "0", Text = "- Select -" });

                ViewBag.Stocklots = (from x in ctx.Stocklots.Where(x => x.StoreId.Equals(user.Result.StoreId))
                                     select new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
                ((List<SelectListItem>)ViewBag.Stocklots).Insert(0, new SelectListItem { Value = "0", Text = "- Select -" });

                return View();
            }
           
        }

        [Authorize(Roles = "store")]
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var user = UserManager.FindByNameAsync(User.Identity.Name);

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

                ViewBag.Baskets = (from x in ctx.Baskets.Where(x => x.StoreId.Equals(user.Result.StoreId))
                                      select new SelectListItem
                                      {
                                          Text = x.Name,
                                          Value = x.Id.ToString()
                                      }).ToList();
                ((List<SelectListItem>)ViewBag.Baskets).Insert(0, new SelectListItem { Value = "0", Text = "- Select -" });
                if (item.BasketId != null)
                    ((List<SelectListItem>)ViewBag.Baskets).FirstOrDefault(x => x.Value.Equals(((int)item.BasketId).ToString())).Selected = true;

                ViewBag.Stocklots = (from x in ctx.Stocklots.Where(x => x.StoreId.Equals(user.Result.StoreId))
                                   select new SelectListItem
                                   {
                                       Text = x.Name,
                                       Value = x.Id.ToString()
                                   }).ToList();
                ((List<SelectListItem>)ViewBag.Stocklots).Insert(0, new SelectListItem { Value = "0", Text = "- Select -" });
                if (item.StocklotId != null)
                    ((List<SelectListItem>)ViewBag.Stocklots).FirstOrDefault(x => x.Value.Equals(((int)item.StocklotId).ToString())).Selected = true;

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

        [Authorize(Roles = "store")]
        [HttpPost]
        public JsonResult AddToCart(List<long> idList)
        {
            if (Session["cart"] == null)
                Session["cart"] = new List<long>(idList);
            else
                Session["cart"] = ((List<long>)Session["cart"]).Union(idList).ToList();


            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "store")]
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

        [HttpPost]
        public JsonResult UploadMedia(HttpPostedFileBase itemImage)
        {
            var user = UserManager.FindByNameAsync(User.Identity.Name);

            using (var ctx = new CPDataContext())
            {
                long itemId = long.Parse(Request.Form["Id"]);
                string originalName = Path.GetFileName(itemImage.FileName);
                var item = ctx.Items.Single(x => x.Id.Equals(itemId));
                if (item.StoreId.Equals(user.Result.StoreId))
                {
                    ctx.ItemImages.Add(new ItemImage { OriginalName = originalName, ItemId = item.Id });
                    ctx.SaveChanges();

                    string relativePath = string.Format("~/images/items/{0}/", item.Id);
                    string physicalPath = Server.MapPath(relativePath);
                    if (!Directory.Exists(physicalPath))
                        Directory.CreateDirectory(physicalPath);

                    WebImage img = new WebImage(itemImage.InputStream);
                    if (img.Width > 1000)
                        img.Resize(800, 600);

                    img.Save(string.Format("{0}{1}", physicalPath, originalName));
                    return Json(new { message = true }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { message = false }, JsonRequestBehavior.AllowGet);
                }
            }

            
            
        }

        public JsonResult GetItemImages(long Id)
        {
            var user = UserManager.FindByNameAsync(User.Identity.Name);

            using (var ctx = new CPDataContext())
            {
                var media = ctx.ItemImages.Include("Item").Where(x => x.ItemId.Equals(Id) && x.Item.StoreId.Equals(user.Result.StoreId)).Select(x => new
                {
                    url = "/images/items/" + x.ItemId + "/" + x.OriginalName,
                    caption = x.OriginalName,
                    id = x.Id
                }).ToList();
                HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                return Json(media, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult DeleteItemImage()
        {
            var user = UserManager.FindByNameAsync(User.Identity.Name);

            using (var ctx = new CPDataContext())
            {
                long itemImageId = long.Parse(Request.Form["key"]);
                var itemImage = ctx.ItemImages.Include("Item").Single(x => x.Id.Equals(itemImageId));

                if (itemImage.Item.StoreId.Equals(user.Result.StoreId))
                {

                    ctx.ItemImages.Remove(itemImage);
                    ctx.SaveChanges();

                    string relativePath = string.Format("~/images/items/{0}/{1}", itemImage.ItemId, itemImage.OriginalName);
                    string physicalPath = Server.MapPath(relativePath);
                    System.IO.File.Delete(physicalPath);

                    return Json(new { message = true }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { message = false }, JsonRequestBehavior.AllowGet);
                }
            }
        }


        [HttpPost]
        public JsonResult SetPrimaryImage(long id)
        {
            using (var ctx = new CPDataContext())
            {
                var item = ctx.ItemImages.Find(id);
                var query = ctx.ItemImages.Where(_ => _.ItemId.Equals(item.ItemId));
                foreach (ItemImage image in query)
                {
                    image.IsPrimary = false;
                }
                item.IsPrimary = true;
                ctx.SaveChanges();

            }
            return Json(new { message = true }, JsonRequestBehavior.AllowGet);
        }
    }
}