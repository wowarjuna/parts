﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.Data.DTO
{
    public class SearchItemDTO
    {
        public string name { get; set; }
        public string description { get; set; }
        public string modelNo { get; set; }
        public int? year { get; set; }
    }
}