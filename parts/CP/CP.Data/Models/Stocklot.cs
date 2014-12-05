using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.Data.Models
{
    [Table("Stocklots")]
    public class Stocklot : CPBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string CreatedBy { get; set; }

        public int StoreId { get; set; }

        public double? Value { get; set; }
    }
}
