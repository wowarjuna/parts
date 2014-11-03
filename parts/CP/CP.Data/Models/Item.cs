using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.Data.Models
{
    [Table("Items")]
    public class Item
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }

        public int StoreId { get; set; }

        public int BrandId { get; set; }

        public int ModelId { get; set; } 

        public string Description { get; set; }

        public string StoreInfo { get; set; }

        public bool Active { get; set; }

        public int Qty { get; set; }
    }
}
