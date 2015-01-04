using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CP.Models
{
    public class StocklotChartRequest
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }


    public class StocklotChartResponse
    {
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public double? QuotedVal { get; set; }
        public double? Return { get; set; }
    }

    public class SalesChartResponse
    {
        public string Month { get; set; }
        public double? Val { get; set; }
    }
}