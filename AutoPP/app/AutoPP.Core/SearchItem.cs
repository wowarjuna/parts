using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Core.DomainModel;

namespace AutoPP.Core
{
    public class SearchItem
    {
        public string Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual int Year { get; set; }
        public virtual int Category { get; set; }
        public virtual int ModelId { get; set; }
        public virtual int MakeId { get; set; }
        public virtual int VendorId { get; set; }
        
    }
}
