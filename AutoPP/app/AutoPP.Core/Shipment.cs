using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Core.DomainModel;
using System.ComponentModel.DataAnnotations;

namespace AutoPP.Core
{

    public class Shipment : Entity
    {
        [Required]
        [Display(Name = "Shipment Date")]
        public virtual DateTime ShipmentDate { get; set; }
        [Required]
        public virtual string Description { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}
