using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Core.DomainModel;

namespace AutoPP.Core
{
    public class Category : Entity
    {
        private IList<Category> _subs;

        public Category()
        {
            _subs = new List<Category>();
        }

        public virtual string Name { get; set; }
        public virtual int Parent { get; set; }

        public virtual IList<Category> Subs { get { return _subs; } set { _subs = value; } }
    }
}
