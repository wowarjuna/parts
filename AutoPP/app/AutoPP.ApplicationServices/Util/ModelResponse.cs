using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoPP.Core;

namespace AutoPP.ApplicationServices.Util
{
    public class ModelResponse
    {
        private IList<Model> _list;

        public ModelResponse() {
            _list = new List<Model>();
        }

        public IList<Model> Models 
        {
            get { return _list; }
            set { _list = value; }
        }

        public int Count { get; set; }
    }
}
