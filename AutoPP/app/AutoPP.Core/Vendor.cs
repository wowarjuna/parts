using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Core.DomainModel;
using System.ComponentModel.DataAnnotations;

namespace AutoPP.Core
{
    public class Vendor : Entity
    {
        [Required]
        public virtual string Name { get; set; }
        [Required]
        public virtual string Email { get; set; }
        public virtual string Address { get; set; }

        public virtual string City { get; set; }
        public virtual string PostalCode { get; set; }
        public virtual string Country { get; set; }
        [Required]
        public virtual string Phone { get; set; }
        public virtual string Mobile { get; set; }

        public virtual string Fax { get; set; }

        public virtual bool? IsActive { get; set; }
             
    }
}
