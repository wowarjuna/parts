using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace AutoPP.Web.Controllers.Helpers
{
    public static class HtmlHelperExtensions
    {
        private static readonly Random rnd = new Random();

        public static int RandomNumber(this HtmlHelper helper)
        {
            return rnd.Next();
        }

       
    }
}
