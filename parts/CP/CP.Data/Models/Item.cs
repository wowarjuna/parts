﻿using System;
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
    }
}
