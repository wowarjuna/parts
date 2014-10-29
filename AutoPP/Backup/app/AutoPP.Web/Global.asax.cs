namespace AutoPP.Web
{
    using System;
    using System.Reflection;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;

    using Castle.Windsor;

    using CommonServiceLocator.WindsorAdapter;

    using log4net.Config;

    using Microsoft.Practices.ServiceLocation;

    using SharpArch.Core.NHibernateValidator.ValidatorProvider;
    using SharpArch.Data.NHibernate;
    using SharpArch.Web.Areas;
    using SharpArch.Web.Castle;
    using SharpArch.Web.ModelBinder;
    using SharpArch.Web.NHibernate;

    using AutoPP.Data.NHibernateMaps;
    using AutoPP.Web.CastleWindsor;
    using AutoPP.Web.Controllers;
    using System.Configuration;
    using SolrNet;
    using SolrNet.Impl;
    using AutoPP.Web.Controllers.Util;
    using System.IO;
    using System.Text;
    using SolrNet.Exceptions;
    using AutoPP.Web.Controllers.Util.Binders;
    using Castle.Facilities.WcfIntegration;
    using AutoPP.ApplicationServices.Impl;
    using System.ServiceModel.Activation;
    using SharpArch.Wcf.NHibernate;

    //// Note: For instructions on enabling IIS6 or IIS7 classic mode,
    //// visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        private static readonly string solrURL = ConfigurationManager.AppSettings["solrUrl"];


        #region Constants and Fields

        private WebSessionStorage webSessionStorage;

        #endregion

        #region Public Methods

        public override void Init()
        {
            base.Init();

            // The WebSessionStorage must be created during the Init() to tie in HttpApplication events
            this.webSessionStorage = new WebSessionStorage(this);
            
        }

        #endregion

        #region Methods

        /// <summary>
        /// Due to issues on IIS7, the NHibernate initialization cannot reside in Init() but
        /// must only be called once.  Consequently, we invoke a thread-safe singleton class to
        /// ensure it's only initialized once.
        /// </summary>
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            NHibernateInitializer.Instance().InitializeNHibernateOnce(this.InitializeNHibernateSession);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            // Useful for debugging
            Exception ex = this.Server.GetLastError();
            var reflectionTypeLoadException = ex as ReflectionTypeLoadException;
        }

        protected void Application_Start()
        {
            XmlConfigurator.Configure();

            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new AreaViewEngine());
            ViewEngines.Engines.Add(new RazorViewEngine());

            ModelBinders.Binders.DefaultBinder = new SharpModelBinder();

            ModelValidatorProviders.Providers.Add(new NHibernateValidatorProvider());

            var connection = new SolrConnection(solrURL);
            var loggingConnection = new LoggingConnection(connection);
            Startup.Init<VItem>(loggingConnection);
            ModelBinders.Binders[typeof(SearchParameters)] = new SearchParametersBinder();
            
            //AddInitialDocuments();

            this.InitializeServiceLocator(Startup.Container);

            AreaRegistration.RegisterAllAreas();
            RouteRegistrar.RegisterRoutesTo(RouteTable.Routes);
            //RouteTable.Routes.Add(new ServiceRoute("Services", new SharpArch.Wcf.NHibernate.ServiceHostFactory(), typeof(RequestService)));

           
        }

        /// <summary>
        /// Adds some sample documents to Solr
        /// </summary>
        private void AddInitialDocuments()
        {
            try
            {
                var solr = ServiceLocator.Current.GetInstance<ISolrOperations<VItem>>();
                solr.Delete(SolrQuery.All);
                var connection = ServiceLocator.Current.GetInstance<ISolrConnection>();
                foreach (var file in Directory.GetFiles(Server.MapPath("/exampledocs"), "*.xml"))
                {
                    connection.Post("/update", File.ReadAllText(file, Encoding.UTF8));
                }
                solr.Commit();
                solr.BuildSpellCheckDictionary();
            }
            catch (SolrConnectionException)
            {
                throw new Exception(string.Format("Couldn't connect to Solr. Please make sure that Solr is running on '{0}' or change the address in your web.config, then restart the application.", solrURL));
            }
        }

        /// <summary>
        /// Instantiate the container and add all Controllers that derive from
        /// WindsorController to the container.  Also associate the Controller
        /// with the WindsorContainer ControllerFactory.
        /// </summary>
        protected virtual void InitializeServiceLocator(IServiceLocator solrLocator)
        {
            IWindsorContainer container = new WindsorContainer();
            //container.AddFacility<WcfFacility>();
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(container));

            container.RegisterControllers(typeof(HomeController).Assembly);
            ComponentRegistrar.AddComponentsTo(container, solrLocator);
                      
            
            ServiceLocator.SetLocatorProvider(() => new WindsorServiceLocator(container));

            
        }

        /// <summary>
        /// If you need to communicate to multiple databases, you'd add a line to this method to
        /// initialize the other database as well.
        /// </summary>
        private void InitializeNHibernateSession()
        {
            NHibernateSession.Init(
                this.webSessionStorage, 
                new[] { this.Server.MapPath("~/bin/AutoPP.Data.dll") }, 
                new AutoPersistenceModelGenerator().Generate(), 
                this.Server.MapPath("~/NHibernate.config"));

           
        }

       

        #endregion
    }
}