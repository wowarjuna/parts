using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Core.DomainModel;
using System.IO;

namespace AutoPP.Core
{
    public class Gallery : Entity
    {
        public virtual Guid GalleryId { get; set; }
        public virtual string Name { get; set; }
        //public virtual int ItemId { get; set; }
        public virtual Item Item { get; set; }
        public virtual string PrimaryResource { get; set; }
    }

    public class Media
    {
        public string FileName { get; set; }
        public DateTime Date { get; set; }
        public Stream FileStream { get; set; }
    }
}
