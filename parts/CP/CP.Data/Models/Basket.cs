using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.Data.Models
{
    [Table("Baskets")]
    public class Basket : CPBase
    {
        public string Name { get; set; }
        public int StoreId { get; set; }
        public string Description { get; set; }
    }
}
