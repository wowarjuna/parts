using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.Data.Models
{
    [Table("ItemImages")]
    public class ItemImage
    {
       
        public long Id { get; set; }
        public string OriginalName { get; set; }
        public string Location { get; set; }
        public long ItemId { get; set; }

        [ForeignKey("ItemId")]
        public Item Item { get; set; }
    }
}
