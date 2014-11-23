using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.Data.Models
{
    [Table("Invoices")]
    public class Invoice : CPBase
    {
        public double Total { get; set; }

        public virtual ICollection<Sale> Items { get; set; }
    }
}
