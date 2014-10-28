using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web;


namespace AutoPP.Web.Controllers.Helpers
{
    public static class MenuHelper
    {
        public static MvcHtmlString Menu(this HtmlHelper helper)
        {
            var ulTag = new TagBuilder("ul");
            ulTag.MergeAttribute("id", "mainMenu");
            // Requests
            var liTag = new TagBuilder("li");
            var _aTag =  new TagBuilder("a") { InnerHtml = "Requests" };
           

            // Items
                      
            
            if (HttpContext.Current.User.IsInRole("admin"))
            {
                // Vendors
                liTag = new TagBuilder("li");
                _aTag = new TagBuilder("a") { InnerHtml = "Vendors" };
                _aTag.MergeAttribute("href", "/Vendor/Items");
                liTag.InnerHtml += _aTag.ToString();
                ulTag.InnerHtml += liTag.ToString();

                // Master
                liTag = new TagBuilder("li");
                _aTag = new TagBuilder("a") { InnerHtml = "Master Data" };
                _aTag.MergeAttribute("href", "/Admin/Dashboard");
                liTag.InnerHtml += _aTag.ToString();
                ulTag.InnerHtml += liTag.ToString();
            }

            if (HttpContext.Current.User.IsInRole("vendor"))
            {
                liTag = new TagBuilder("li");
                _aTag = new TagBuilder("a") { InnerHtml = "Items" };
                _aTag.MergeAttribute("href", "/Item/Items");
                liTag.InnerHtml += _aTag.ToString();
                ulTag.InnerHtml += liTag.ToString();


                liTag = new TagBuilder("li");
                _aTag = new TagBuilder("a") { InnerHtml = "My Account" };
                _aTag.MergeAttribute("href", "/Vendor/Dashboard");
                liTag.InnerHtml += _aTag.ToString();
                ulTag.InnerHtml += liTag.ToString();

                liTag = new TagBuilder("li");
                _aTag = new TagBuilder("a") { InnerHtml = "Requests" };
                _aTag.MergeAttribute("href", "/Request/Items");
                liTag.InnerHtml += _aTag.ToString();
                ulTag.InnerHtml += liTag.ToString();

                liTag = new TagBuilder("li");
                _aTag = new TagBuilder("a") { InnerHtml = "Shipments" };
                _aTag.MergeAttribute("href", "/Vendor/Shipments");
                liTag.InnerHtml += _aTag.ToString();
                ulTag.InnerHtml += liTag.ToString();

                liTag = new TagBuilder("li");
                _aTag = new TagBuilder("a") { InnerHtml = "Reports" };
                _aTag.MergeAttribute("href", "/Admin/ReportDashboard");
                liTag.InnerHtml += _aTag.ToString();
                ulTag.InnerHtml += liTag.ToString();
            }


            if (HttpContext.Current.User.IsInRole("customer"))
            {
                liTag = new TagBuilder("li");
                _aTag = new TagBuilder("a") { InnerHtml = "Requests" };
                _aTag.MergeAttribute("href", "/Request/Items");
                liTag.InnerHtml += _aTag.ToString();
                ulTag.InnerHtml += liTag.ToString();

                liTag = new TagBuilder("li");
                _aTag = new TagBuilder("a") { InnerHtml = "Shipments" };
                _aTag.MergeAttribute("href", "/Vendor/ShipmentList");
                liTag.InnerHtml += _aTag.ToString();
                ulTag.InnerHtml += liTag.ToString();
            }

            /*liTag = new TagBuilder("li");
            _aTag = new TagBuilder("a") { InnerHtml = "My Account" };
            _aTag.MergeAttribute("href", "/Vendor/Dashboard");
            liTag.InnerHtml += _aTag.ToString();
            ulTag.InnerHtml += liTag.ToString();*/
            

            // Reports
           


            return new MvcHtmlString(ulTag.ToString());
        }
    }
}
