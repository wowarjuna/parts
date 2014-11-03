using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.Data.Models
{
    [Table("Stores")]
    public class Store : CPBase
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public double LocationLon { get; set; }

        public double LocationLat { get; set; }
    }
}
