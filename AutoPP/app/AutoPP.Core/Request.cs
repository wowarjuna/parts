using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Core.DomainModel;
using System.ComponentModel.DataAnnotations;

namespace AutoPP.Core
{
    public class Request : Entity
    {
        [Required]
        public virtual string Name { get; set; }
        [Required]
        public virtual string Description { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name="Contact Number")]
        public virtual string Phone { get; set; }
        public virtual User User { get; set; }
        public virtual DateTime ModifiedOn { get; set; }
    }
}
