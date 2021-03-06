﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public DateTime Created { get; set; }

        public DateTime? Modified { get; set; }

        public double? QuotedPrice { get; set; }

        public int? Year { get; set; }

        public string PartNo { get; set; }

        public int? BasketId { get; set; }

        public int? StocklotId { get; set; }

        [JsonIgnore]
        public virtual ICollection<ItemImage> Images { get; set; }

        [ForeignKey("StoreId")]
        [JsonIgnore]
        public virtual Store Store { get; set; }
    }
}
