using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoPP.Core;

namespace AutoPP.ApplicationServices.Util
{
    public class CustomerRequestParam
    {
        public int StartFrom { get; set; }
        public int Offset { get; set; }
        public Dictionary<string, object> Filters { get; set; }
        public string UserId { get; set; }
    }

    public class CustomerRequestResponse
    {
        private List<Request> _data;

        public int Count { get; set; }

        public CustomerRequestResponse()
        {
            _data = new List<Request>();
        }

        public List<Request> Data { get { return _data; } set { _data = value; } }
    }
}
