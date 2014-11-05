using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.Data.Models
{
    [Table("Sales")]
    public class Sale
    {
        [Key]
        public long Id { get; set; }

        public long ItemId { get; set; }

        public int Qty { get; set; }

        public double UnitPrice { get; set; }

        public double Total { get; set; }
    }
}
