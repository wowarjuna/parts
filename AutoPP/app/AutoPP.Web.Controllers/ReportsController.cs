using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using AutoPP.ApplicationServices;
using AutoPP.ApplicationServices.Util;

namespace AutoPP.Web.Controllers
{
    public class ReportsController : Controller
    {
        private readonly IItemsService _service;
        private readonly IReportService _reportService;

        public ReportsController(IItemsService service, IReportService ReportService)
        {
            _service = service;
            _reportService = ReportService;
        }

        public ActionResult VisitsByMakeReport()
        {
            ViewBag.Makes = _service.GetMakes();
            return View();
        }

       
        public JsonResult Visits(int Id)
        {
            if (Id.Equals(0))
            {
                var _result = from _r in _reportService.GetVisits(new ReportRequest { CallerId = 0, VendorId = 4 }).Values
                              select new { Name = _r.Key, Value = _r.Value };
                return Json(_result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var _result = from _r in _reportService.GetVisitByMake(new ReportRequest { CallerId = Id, VendorId = 4, Make = Id }).Values
                              select new { Name = _r.Key, Value = _r.Value };
                return Json(_result, JsonRequestBehavior.AllowGet);
            }
            
        }

        
    }
}
