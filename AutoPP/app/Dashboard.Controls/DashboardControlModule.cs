using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;

namespace Dashboard.Controls
{
    public class DashboardControlModule : IModule
    {
        private readonly IRegionViewRegistry _regionViewRegistry;
        #region IModule Members

        public DashboardControlModule(IRegionViewRegistry regionViewRegistry)
        {
            _regionViewRegistry = regionViewRegistry;
            
        }

        public void Initialize()
        {
            //this._regionViewRegistry.RegisterViewWithRegion("MainRegion", typeof(Views.HelloWorldView));
            this._regionViewRegistry.RegisterViewWithRegion("MainRegion", typeof(Views.RequestView));
        }

        #endregion
    }
}
