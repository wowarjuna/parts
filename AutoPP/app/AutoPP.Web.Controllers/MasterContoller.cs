using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using AutoPP.ApplicationServices;
using AutoPP.Web.Controllers.Util;
using AutoPP.ApplicationServices.Util;
using AutoPP.Core;

namespace AutoPP.Web.Controllers
{
    public class MasterController : Controller
    {
        private readonly IItemsService _service;

        public MasterController(IItemsService service)
        {
            _service = service;
        }

        public ActionResult Index()
        {
            

            return View();
        }

        public ActionResult Models()
        {
           ViewBag.Makes = _service.GetMakes();
           return View();
        }

        public JsonResult JsonModels(DataTableParam param)
        {
            Dictionary<string, object> _filters = new Dictionary<string, object>();
            var _params = param.cFilters.Split(new char[] {','});
            _filters.Add("Model", int.Parse(_params[0]));

            var _data = _service.GetModels(new ModelRequest { StartFrom = param.iDisplayStart, Offset = param.iDisplayLength, Filters = _filters});
            var _result = new
            {
                sEcho = param.sEcho,
                iTotalRecords = _data.Count,
                iTotalDisplayRecords = _data.Count,
                aaData = from _model in _data.Models
                         select new { _model.ModelNo, _model.Name, Year = string.Format("{0} - {1}", _model.YearFrom, _model.YearTo), Make = _model.Make.Name, _model.Id }
            };
            return Json(_result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddModel()
        {
            ViewBag.Makes = _service.GetMakes();
            return View();
        }

        [HttpPost]
        public ActionResult AddModel(Model model)
        {
            if (ModelState.IsValid)
            {
                _service.AddModel(new ModelRequest { Model = model });
                return RedirectToAction("Models");
            }
            else
            {
                ViewBag.Makes = _service.GetMakes();
                return View();
            }
           
        }

        public ActionResult EditModel(int Id)
        {
            ViewBag.Makes = _service.GetMakes();
            return View(_service.GetModel(Id));
        }

        [HttpPost]
        public ActionResult EditModel(Model model)
        {
            _service.UpdateModel(new ModelRequest { Model = model });
            return RedirectToAction("Models");
        }

        public ActionResult DeleteModel(int Id)
        {
            _service.DeleteModel(new ModelRequest { ModelId = Id });
            return RedirectToAction("Models");
        }

        public ActionResult Makes()
        {
            return View();
        }
    }
}
