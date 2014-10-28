using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using AutoPP.ApplicationServices;
using AutoPP.Core;
using System.IO;
using System.Configuration;
using AutoPP.ApplicationServices.Util;
using System.Web;
using AutoPP.Web.Controllers.Util;
using System.Drawing;
using AutoPP.Web.Controllers.Helpers;



namespace AutoPP.Web.Controllers
{
    public class ItemController : Controller
    {
        private IItemsService _sItems;
        private IVendorService _sVendor;

        public ItemController(IItemsService sItems, IVendorService sVendor)
        {
            this._sItems = sItems;
            this._sVendor = sVendor;
        }

        public JsonResult GetMake(int Id)
        {
            var _make = this._sItems.GetMake(Id);
            var _result = new
            {
                Models = from _jMake in _make.Models
                         select new { Id = _jMake.Id,  Name = _jMake.Name, From = _jMake.YearFrom, To = _jMake.YearTo, ModelNo = _jMake.ModelNo } 
            };
            return Json(_result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Gallery(int Id)
        {
            ViewBag.Item = _sItems.Get(Id);
            return View();
        }

        private List<Media> GetFiles(Guid FolderId)
        {
            List<Media> _result = new List<Media>();
            
            var _files = Directory.GetFiles(string.Format("{0}{1}\\", ConfigurationManager.AppSettings["GALLERY_FOLDER_PATH"], FolderId.ToString()));
            foreach (var _file in _files)
                _result.Add(new Media { FileName = _file });
            return _result;
        }

        public ActionResult Items()
        {
            ViewBag.Makes = this._sItems.GetMakes();
            ViewBag.Categories = this._sItems.GetCategories(0);
            return View();
        }

        public ActionResult AddItem()
        {
            ViewBag.Categories = this._sItems.GetCategories(0);
            ViewBag.Makes = this._sItems.GetMakes();
            return View();
        }

        public ActionResult AddItemImages(int id)
        {
            var _obj = _sItems.Get(id);
            return View();
        }

        [HttpPost]
        public ActionResult AddItem(FormCollection data)
        {
            var _make = _sItems.GetMake(int.Parse(data["make"]));
            var _vendor = _sVendor.Get(1);

            var _item = new Item { Description = data["description"], Name = data["name"], Make = _make, 
                Vendor = _vendor, Year = data["year"], ModifiedOn = DateTime.Now };
            var _categories = _sItems.GetCategories(data["categories"].Split(new char[] { ',' }).ToList<string>()
                .ConvertAll<int>(delegate(string _cat) { return int.Parse(_cat); }));
            foreach (var _category in _categories)
                _item.Categories.Add(_category);
            if (data["model"] != null)
            {
                var _models = from _m in _make.Models
                              where data["model"].Split(new char[] { ',' }).ToList<string>().Contains(_m.Id.ToString())
                              select _m;
                foreach (var _model in _models)
                    _item.Models.Add(_model);
            }
            _sItems.Add(_item);

            Directory.CreateDirectory(string.Format("{0}{1}", ConfigurationManager.AppSettings["GALLERY_FOLDER_PATH"], _item.Galleries.First().GalleryId));

            return RedirectToAction("Items");
        }

        public ActionResult Edit(int Id)
        {
            var _item = this._sItems.Get(Id);
            ViewBag.Item = _item;

            ViewBag.Categories = this._sItems.GetCategories(0);
            ViewBag.Makes = this._sItems.GetMakes();
            if(_item.Make != null)
                ViewBag.Models = from _m in this._sItems.GetMake(_item.Make.Id).Models
                                 where !_item.Models.Contains(_m)
                                        select _m;
            return View();
        }

        [HttpPost]
        public ActionResult SetGalleryPrimaryImage(FormCollection data)
        {
            var _item = this._sItems.Get(int.Parse(data["id"]));
            var _gallery = _item.Galleries.Single( g => g.GalleryId.Equals(Guid.Parse(data["gallery"])));
            _gallery.PrimaryResource = data["primary"];
            this._sItems.UpdateGallery(_gallery);
            return RedirectToAction("Gallery", new { Id = data["id"] });
        }

        public ActionResult DeleteGalleryImage(int? ItemId, string GalleryId, string Image)
        {
            System.IO.File.Delete(string.Format("{0}{1}\\{2}", ConfigurationManager.AppSettings["GALLERY_FOLDER_PATH"], GalleryId, Path.GetFileName(Image)));
            return RedirectToAction("Gallery", new { Id = ItemId });
        }

        [HttpPost]
        public ActionResult UploadGalleryImage(FormCollection data)
        {
            HttpPostedFileBase _image = Request.Files["image"] as HttpPostedFileBase;
            Image _temp = Image.FromStream(_image.InputStream);
            if (_temp.Width > 640)
            {
                Image _output = _temp.Resize(640, 480);
                _output.Save(string.Format("{0}{1}\\{2}", ConfigurationManager.AppSettings["GALLERY_FOLDER_PATH"], data["galllery"], Path.GetFileName(_image.FileName)));
            }
            else
            {
                _image.SaveAs(string.Format("{0}{1}\\{2}", ConfigurationManager.AppSettings["GALLERY_FOLDER_PATH"], data["galllery"], Path.GetFileName(_image.FileName)));
            }

            return RedirectToAction("Gallery", new { Id = data["item-id"] });
        }

        public ActionResult Delete(int Id)
        {
            this._sItems.Delete(Id);
            return RedirectToAction("Items");
        }

        public JsonResult JsonItems(DataTableParam param)
        {
            var _request = new ItemParameters { PageSize = param.iDisplayLength, StartIndex = param.iDisplayStart, FreeSearch = param.sSearch };
            var _sFilters =  param.cFilters.Split(new char[] {','});
            _request.Criterias.Add("category",_sFilters[0]);
            _request.Criterias.Add("make", _sFilters[1]);
            var _response = _sItems.GetItems(_request);
            var _result = new
            {
                sEcho = param.sEcho,
                iTotalRecords = _response.Count,
                iTotalDisplayRecords = _response.Count,
                aaData = from _item in _response.Items
                         select new { _item.Name, _item.Description, _item.Id }
            };
            return Json(_result, JsonRequestBehavior.AllowGet);
        }


    }
}
