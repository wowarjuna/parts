using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CP.Data;
using CP.Data.DTO;

namespace CP.Controllers
{
    public class SearchController : Controller
    {
        //
        // GET: /Search/
        public ActionResult Index()
        {
            return View();
        }

       
        [HttpGet]
        public JsonResult Query(int page, int category, int brand, string model, int year, string area, string text, string stamp)
        {
            PaginatedItem<SearchItemDTO> pager = QueryManager.Query((page - 1) * 5, category,
                brand,
                model != "model" ? model : "",
                year,
                text != "criteria" ? text : "");
            pager.page = page;

            return Json(new { category = category, brand = brand, model = model, year = year, area = area, text = text, pager = pager }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Categories()
        {
            return Json(QueryManager.Categories(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Get(long itemId, string stamp)
        {
            return Json(QueryManager.Get(itemId), JsonRequestBehavior.AllowGet);
        }
	}

   
}