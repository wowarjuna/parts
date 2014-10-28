using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.UnityExtensions;
using System.Windows;
using Dashboard.Controls;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;

namespace Dashboard
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return this.Container.Resolve<Shell>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            App.Current.MainWindow = (Window)this.Shell;
            App.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();

            ModuleCatalog _moduleCatalog = (ModuleCatalog)this.ModuleCatalog;
            _moduleCatalog.AddModule(typeof(DashboardControlModule));
        }

    }
}
