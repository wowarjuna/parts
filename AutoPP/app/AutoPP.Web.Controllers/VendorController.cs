using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using AutoPP.ApplicationServices;
using AutoPP.Core;
using AutoPP.Web.Controllers.Util;

namespace AutoPP.Web.Controllers
{
    public class VendorController : Controller
    {
        private IItemsService _sItems;
        private IVendorService _sVendor;

        public VendorController(IItemsService sItems, IVendorService sVendor)
        {
            this._sItems = sItems;
            this._sVendor = sVendor;
        }

        //[Authorize(Roles="Vendor")]
        public ActionResult Index()
        {
            return View();
        }

      

        //[Authorize(Roles = "Vendor")]
        public ActionResult AddItem()
        {
            ViewBag.Categories = this._sItems.GetCategories(0);
            ViewBag.Makes = this._sItems.GetMakes();
            return View();
        }

        [HttpPost]
        public ActionResult AddItem(FormCollection data)
        {
            var _item = new Item { Description = data["description"], Name = data["name"] };
            var _categories = _sItems.GetCategories(data["categories"].Split(new char[] { ',' }).ToList<string>()
                .ConvertAll<int>(delegate(string _cat) { return int.Parse(_cat); }));
            foreach(var _category in _categories)
                _item.Categories.Add(_category);

            _sItems.Add(_item);

            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Vendor data)
        {
            if (ModelState.IsValid)
            {
                _sVendor.Register(new Vendor
                {
                    Address = data.Address,
                    City = data.City,
                    Country = data.Country,
                    Name = data.Name,
                    PostalCode = data.PostalCode,
                    Phone = data.Phone,
                    Mobile = data.Mobile,
                    IsActive = false,
                    Email = data.Email
                });
                return View("RegisterSuccess");
            }
            else
            {
                return View();
            }
        }

        //[Authorize(Roles = "Vendor")]
        public ActionResult Items()
        {
            var _results = _sVendor.AllVendors();
            return View(_results);
        }

        public ActionResult Vendors()
        {
            var _model = _sVendor.AllVendors();
            return View(_model);
        }

        public ActionResult Edit(int Id)
        {
            var _result = _sVendor.Get(Id);
            return View(_result);
        }

        public ActionResult Approve(int Id)
        {
            var _obj = _sVendor.Get(Id);
            _obj.IsActive = true;
            _sVendor.Update(_obj);
            return RedirectToAction("Items");
        }

        public ActionResult Reject(int Id)
        {
            var _obj = _sVendor.Get(Id);
            _obj.IsActive = false;
            _sVendor.Update(_obj);
            return RedirectToAction("Items");
        }


        public JsonResult JsonVendors(DataTableParam param)
        {
            var _vendors = _sVendor.AllVendors();
            var _result = new
            {
                sEcho = param.sEcho,
                iTotalRecords = _vendors.Count,
                iTotalDisplayRecords = _vendors.Count,
                aaData = from _vendor in _vendors
                         select new { _vendor.Name, _vendor.Phone, _vendor.Email, _vendor.Id, _vendor.IsActive }
            };
            return Json(_result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Upgrade()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }

        [Authorize(Roles = "vendor")]
        public ActionResult Shipments()
        {
            return View();
        }

        [Authorize(Roles = "customer")]
        public ActionResult ShipmentList()
        {
            return View();
        }

        public ActionResult Shipment(int id)
        {
            var _shipment = _sVendor.GetShipment(id);
            return View(_shipment);
        }

        public JsonResult JsonShipments(DataTableParam param)
        {
            var _shipments = _sVendor.GetShipments(4);
            var _result = new
            {
                sEcho = param.sEcho,
                iTotalRecords = _shipments.Count,
                iTotalDisplayRecords = _shipments.Count,
                aaData = from _shipment in _shipments
                         select new { ShipmentDate = _shipment.ShipmentDate.ToString("MMM dd, yyyy"), _shipment.Description, _shipment.Id }
            };
            return Json(_result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddShipment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddShipment(Shipment shipment)
        {
            if (ModelState.IsValid)
            {
                var _vendor = _sVendor.Get(4);
                shipment.Vendor = _vendor;

                _sVendor.AddShipment(shipment);
                
                return RedirectToAction("Shipments");
            }
            else
                return View();

        }

        public ActionResult EditShipment(int id)
        {
            var _shipment = _sVendor.GetShipment(id);
            return View(_shipment);
        }

        [HttpPost]
        public ActionResult EditShipment(FormCollection data)
        {
            var _shipment = _sVendor.GetShipment(int.Parse(data["Id"]));
            _shipment.Description = data["Description"];
            _shipment.ShipmentDate = DateTime.Parse(data["ShipmentDate"]);
            _sVendor.UpdateShipment(_shipment);
            return RedirectToAction("Shipments");
        }

        public ActionResult DeleteShipment(int Id)
        {
           
            return RedirectToAction("Shipments");
        }

    }
}
