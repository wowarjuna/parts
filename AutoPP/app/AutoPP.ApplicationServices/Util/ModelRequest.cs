using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoPP.Core;

namespace AutoPP.ApplicationServices.Util
{
    public class ModelRequest
    {
        public int StartFrom { get; set; }
        public int Offset { get; set; }
        public Model Model { get; set; }
        public Dictionary<string, object> Filters { get; set; }
        public int ModelId { get; set; }
    }
}
