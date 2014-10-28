namespace AutoPP.Web.CastleWindsor
{
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;

    using NHibernate.Validator.Engine;

    using SharpArch.Core.NHibernateValidator.CommonValidatorAdapter;
    using SharpArch.Core.PersistenceSupport;
    using SharpArch.Core.PersistenceSupport.NHibernate;
    using SharpArch.Data.NHibernate;
    using SharpArch.Web.Castle;
    using SolrNet;
    using AutoPP.Web.Controllers.Util;
    using Microsoft.Practices.ServiceLocation;
    using AutoPP.ApplicationServices.Impl;
    using AutoPP.ApplicationServices;
    using Castle.Facilities.WcfIntegration;
    using AutoPP.Core;
    using SolrNet.Mapping;

    public class ComponentRegistrar
    {
        #region Public Methods

        public static void AddComponentsTo(IWindsorContainer container, IServiceLocator solrLocator)
        {
            AddGenericRepositoriesTo(container);
            AddCustomRepositoriesTo(container);
            //AddWcfServicesTo(container);
            AddApplicationServicesTo(container);
            AddSolrServices(container, solrLocator);
            

            container.Register(
                    Component.For(typeof(IValidator))
                        .ImplementedBy(typeof(Validator))
                        .Named("validator"));
        }

        #endregion

        #region Methods

        private static void AddSolrServices(IWindsorContainer container, IServiceLocator solrLocator)
        {
            
            container.Register(Component.For(typeof(ISolrReadOnlyOperations<VItem>))
                .Instance(ServiceLocator.Current.GetInstance<ISolrOperations<VItem>>()));
            container.Register(Component.For(typeof(IReadOnlyMappingManager))
                .Instance(solrLocator.GetInstance<IReadOnlyMappingManager>()));
        }

        private static void AddApplicationServicesTo(IWindsorContainer container)
        {
            
            container.Register(
                AllTypes
                    .FromAssemblyNamed("AutoPP.ApplicationServices")
                    .Pick()
                    .WithService.FirstInterface());
        }

        private static void AddCustomRepositoriesTo(IWindsorContainer container)
        {
            container.Register(
                AllTypes
                    .FromAssemblyNamed("AutoPP.Data")
                    .Pick()
                    .WithService.FirstNonGenericCoreInterface("AutoPP.Core"));
        }

        private static void AddGenericRepositoriesTo(IWindsorContainer container)
        {
            container.Register(
                Component.For(typeof(IEntityDuplicateChecker))
                    .ImplementedBy(typeof(EntityDuplicateChecker))
                    .Named("entityDuplicateChecker"));

            container.Register(
                Component.For(typeof(IRepository<>))
                    .ImplementedBy(typeof(Repository<>))
                    .Named("repositoryType"));

            container.Register(
                Component.For(typeof(INHibernateRepository<>))
                    .ImplementedBy(typeof(NHibernateRepository<>))
                    .Named("nhibernateRepositoryType"));

            container.Register(
                Component.For(typeof(IRepositoryWithTypedId<,>))
                    .ImplementedBy(typeof(RepositoryWithTypedId<,>))
                    .Named("repositoryWithTypedId"));

            container.Register(
                Component.For(typeof(INHibernateRepositoryWithTypedId<,>))
                    .ImplementedBy(typeof(NHibernateRepositoryWithTypedId<,>))
                    .Named("nhibernateRepositoryWithTypedId"));

            container.Register(
                    Component.For(typeof(ISessionFactoryKeyProvider))
                        .ImplementedBy(typeof(DefaultSessionFactoryKeyProvider))
                        .Named("sessionFactoryKeyProvider")); 
        }

        private static void AddWcfServicesTo(IWindsorContainer container)
        {
            container.Register(
                Component.For(typeof(IRequestService))
                .ImplementedBy(typeof(RequestService))
                .Named("requestService")
                .DependsOn(Property.ForKey("repository").Eq(new Repository<Request>())));
        }

        #endregion
    }
}