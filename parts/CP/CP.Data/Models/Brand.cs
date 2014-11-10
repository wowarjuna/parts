using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace CP.Data.Models
{
    [Table("Brands")]
    public class Brand : CPBase
    {
        public string Name { get; set; }
    }
}
