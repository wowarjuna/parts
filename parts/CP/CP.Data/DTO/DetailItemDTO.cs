using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.Data.DTO
{
    public class DetailItemDTO
    {

        public long id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string modelNo { get; set; }        
        public int? year { get; set; }

        public List<ItemImageDTO> images { get; set; }
        public StoreInfoDTO store { get; set; }
    }

    public class ItemImageDTO
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class StoreInfoDTO
    {
        public string name { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
    }
}
