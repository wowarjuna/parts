using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.Data.Models
{
    [Table("Models")]
    public class Model : CPBase
    {
        public string Name { get; set; }

        public string ModelNo { get; set; }

        public int FromY { get; set; }

        public int? ToY { get; set; }

        public int BrandId { get; set; }

    }
}
