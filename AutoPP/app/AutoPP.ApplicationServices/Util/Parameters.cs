using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoPP.ApplicationServices.Util
{
    public class ItemParameters
    {
        public const int DefaultPageSize = 5;

        public string FreeSearch { get; set; }
        public int PageSize { get; set; }
        public int StartIndex { get; set; }
        public string Sort { get; set; }
        public IDictionary<string, string> Criterias { get; set; }

        public ItemParameters()
        {
            Criterias = new Dictionary<string, string>();
            PageSize = DefaultPageSize;
            StartIndex = 1;
        }
      

    }


    public class ItemRequestParameters
    {
        public const int DefaultPageSize = 5;

        public string FreeSearch { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public string Sort { get; set; }
        public IDictionary<string, string> Criterias { get; set; }

        public ItemRequestParameters()
        {
            Criterias = new Dictionary<string, string>();
            PageSize = DefaultPageSize;
            PageIndex = 1;
        }

        public int FirstItemIndex
        {
            get
            {
                return (PageIndex - 1) * PageSize;
            }
        }

        public int LastItemIndex
        {
            get
            {
                return FirstItemIndex + PageSize;
            }
        }

    }
}
