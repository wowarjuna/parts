using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoPP.ApplicationServices.Util
{
    public class ReportResponse
    {
        Dictionary<string, object> _objects = new Dictionary<string, object>();

        public Dictionary<string, object> Values
        {
            get { return _objects; }
        }

        public void Add(string Name, object Value)
        {
            _objects.Add(Name, Value);
        }
    }

    public class ReportRequest
    {
        public int CallerId { get; set; }
        public int VendorId { get; set; }
        public int Make { get; set; }
    }
}
