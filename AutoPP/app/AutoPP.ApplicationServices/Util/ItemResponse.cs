using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoPP.Core;


namespace AutoPP.ApplicationServices.Util
{
    public class ItemResponse
    {
        public int Count { get; set; }
        public List<Item> Items { get; set; }
    }
}
