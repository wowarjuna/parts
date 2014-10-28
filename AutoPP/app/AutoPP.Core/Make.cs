using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Core.DomainModel;

namespace AutoPP.Core
{
    public class Make : Entity
    {
        private IList<Model> _models;

        public Make()
        {
            _models = new List<Model>();
        }

        public virtual string Name { get; set; }

        public virtual IList<Model> Models
        {
            get { return _models; }
            set { _models = value; }
        }

    }
}
