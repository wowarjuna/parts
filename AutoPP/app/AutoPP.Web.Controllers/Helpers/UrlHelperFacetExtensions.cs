﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace AutoPP.Web.Controllers.Helpers
{
    public static class UrlHelperFacetExtensions
    {
        public static string SetFacet(this UrlHelper helper, string field, string value)
        {
            return helper.SetParameters(helper.RequestContext.HttpContext.Request.RawUrl, new Dictionary<string, object> {
                {string.Format("f_{0}", field), value},
                {"page", 1},
            });
        }

        public static string RemoveFacet(this UrlHelper helper, string field)
        {
            var noFacet = helper.RemoveParametersUrl(helper.RequestContext.HttpContext.Request.RawUrl, string.Format("f_{0}", field));
            return helper.SetParameter(noFacet, "page", "1");
        }
    }
}
