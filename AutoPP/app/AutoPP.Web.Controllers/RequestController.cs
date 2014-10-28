using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using AutoPP.Core;
using AutoPP.ApplicationServices;
using System.Web.Security;
using AutoPP.Web.Controllers.Util;
using AutoPP.ApplicationServices.Util;

namespace AutoPP.Web.Controllers
{
    public class RequestController : Controller
    {
        private readonly IRequestService _service;
        private readonly IItemsService _itemsService;

        public RequestController(IRequestService service, IItemsService itemsService)
        {
            _service = service;
            _itemsService = itemsService;
        }

        //[Authorize(Roles="Customer")]
        
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles="Customer")]
        public ActionResult Add()
        {
            ModelState.Remove("User");
            
            return View();
        }

        [Authorize(Roles = "Customer")]
        [HttpPost]
        public ActionResult Add(Request request)
        {
            
            if (ModelState.IsValid)
            {
                
                _service.Add(new Request { Name = request.Name, Description = request.Description, Phone = request.Phone,   User = (User)Session["User"], 
                    ModifiedOn = DateTime.Now });
            }
            return RedirectToAction("Items");
        }

        [Authorize(Roles="customer, vendor, admin")]
        public ActionResult Items()
        {
            return Roles.IsUserInRole("Customer") ? View() : View("List");
        }

        public JsonResult JsonRequests(DataTableParam param)
        {
            var _response = new CustomerRequestResponse();
            if(Roles.IsUserInRole(((User)Session["User"]).UserName, "customer"))
                _response = _service.GetRequests(new CustomerRequestParam { StartFrom = param.iDisplayStart, Offset = param.iDisplayLength, UserId = ((User)Session["User"]).UserId.ToString() });
            else
                _response = _service.GetAllRequest(new CustomerRequestParam { StartFrom = param.iDisplayStart, Offset = param.iDisplayLength });

            var _result = new
            {
                param.sEcho,
                iTotalRecords = _response.Count,
                iTotalDisplayRecords = _response.Count,
                aaData = from _request in _response.Data
                         select new { _request.Name, _request.Description, _request.Id, ModifiedOn = _request.ModifiedOn.ToString("MMM d, yyyy"),
                                      _request.Phone,
                                      Refreshed = _request.ModifiedOn.ToString("MMM d,yyyy HH:mm:ss")
                         }
            };
            return Json(_result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(int Id)
        {
            return View(_service.Get(Id));
        }

        public ActionResult Delete(int Id)
        {
            return RedirectToAction("Items");
        }

        public PartialViewResult _RequestFilter()
        {
            ViewBag.Makes = _itemsService.GetMakes();
            return PartialView();
        }

    }
}
