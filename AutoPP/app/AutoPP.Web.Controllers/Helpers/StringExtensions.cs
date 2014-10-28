using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoPP.Web.Controllers.Helpers
{
    public static class StringExtensions
    {
        public static bool NotNullAnd(this string s, Func<string, bool> f)
        {
            return s != null && f(s);
        }
    }
}
