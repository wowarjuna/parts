using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Core.DomainModel;
using System.ComponentModel.DataAnnotations;

namespace AutoPP.Core
{
    public class Model : Entity
    {
        [Required]
        public virtual string Name { get; set; }
        [Required]
        public virtual Make Make { get; set; }
        [Display(Name = "From")]
        public virtual int YearFrom { get; set; }
        [Display(Name = "Model No")]
        public virtual string ModelNo { get; set; }
        [Display(Name = "To")]
        public virtual int YearTo { get; set; }
    }
}
