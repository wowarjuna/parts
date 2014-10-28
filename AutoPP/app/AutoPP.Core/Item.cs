using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Core.DomainModel;

namespace AutoPP.Core
{
    public class Item : Entity
    {
        private IList<Category> _categories;
        private IList<Gallery> _galleries;
        private IList<Model> _models;

        public Item()
        {
            _categories = new List<Category>();
            _galleries = new List<Gallery>();
            _models = new List<Model>();
        }

        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual Make Make { get; set; }
        public virtual Vendor Vendor { get; set; }

        public virtual string VendorMeta { get; set; }
        public virtual int? NoOfHits { get; set; }
        public virtual string Year { get; set; }
        public virtual DateTime ModifiedOn { get; set; }
             
        
        
        public virtual IList<Category> Categories 
        {
            get
            {
                return _categories;
            }
            set
            {
                _categories = value;
            }

       }

        public virtual IList<Gallery> Galleries
        {
            get
            {
                return _galleries;
            }
            set
            {
                _galleries = value;
            }
        }


        public virtual IList<Model> Models
        {
            get
            {
                return _models;
            }
            set
            {
                _models = value;
            }
        }
    }
}
