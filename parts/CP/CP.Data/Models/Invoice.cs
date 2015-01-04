using Newtonsoft.Json;
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

        public int? PaymentMethod { get; set; }

        public string Reference { get; set; }

        public int? StoreId { get; set; }

        public string CreatedBy { get; set; }

        public string Note { get; set; }

        [JsonIgnore]
        public virtual ICollection<Sale> Items { get; set; }
    }
}
