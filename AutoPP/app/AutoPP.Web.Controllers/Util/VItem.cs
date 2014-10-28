using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolrNet.Attributes;

namespace AutoPP.Web.Controllers.Util
{
    public class VItem
    {
        [SolrUniqueKey("id")]
        public string Id { get; set; }

        //[SolrField("sku")]
        //public string SKU { get; set; }

        [SolrField("name")]
        public string Name { get; set; }

        //[SolrField("manu_exact")]
        //public string Manufacturer { get; set; }

        [SolrField("description")]
        public string Description { get; set; }

        [SolrField("cat")]
        public ICollection<string> Categories { get; set; }

        [SolrField("resource")]
        public string Resource { get; set; }


        [SolrField("gallery")]
        public string Gallery { get; set; }

        [SolrField("model")]
        public ICollection<string> Models { get; set; }

        [SolrField("city")]
        public string City { get; set; }


        [SolrField("year")]
        public int Year { get; set; }
        

        /*
        [SolrField("features")]
        public ICollection<string> Features { get; set; }
        
        [SolrField("price")]
        public decimal Price { get; set; }

        [SolrField("popularity")]
        public int Popularity { get; set; }

        [SolrField("inStock")]
        public bool InStock { get; set; }

        [SolrField("timestamp")]
        public DateTime Timestamp { get; set; }

        [SolrField("weight")]
        public double? Weight { get; set; }*/
    }
}
