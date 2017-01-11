using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CP.Data;

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
        public JsonResult Query(int category, int brand, string model, int year, string area, string text, string stamp)
        {            
            return Json(QueryManager.Query(category, 
                brand, 
                model != "model" ? model : "" , 
                text != "criteria" ? text : "" ), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Get(long itemId, string stamp)
        {
            return Json(QueryManager.Get(itemId), JsonRequestBehavior.AllowGet);
        }
	}

   
}