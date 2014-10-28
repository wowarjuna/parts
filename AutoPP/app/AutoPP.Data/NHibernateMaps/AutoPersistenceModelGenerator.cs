using System;
using System.Linq;
using FluentNHibernate.Automapping;
using FluentNHibernate.Conventions;
using AutoPP.Core;
using AutoPP.Data.NHibernateMaps.Conventions;
using SharpArch.Core.DomainModel;
using SharpArch.Data.NHibernate.FluentNHibernate;

namespace AutoPP.Data.NHibernateMaps
{

    public class AutoPersistenceModelGenerator : IAutoPersistenceModelGenerator
    {

        #region IAutoPersistenceModelGenerator Members

        public AutoPersistenceModel Generate()
        {
            return AutoMap.AssemblyOf<Class1>(new AutomappingConfiguration())
                .Conventions.Setup(GetConventions())
                .IgnoreBase<Entity>()
                .IgnoreBase(typeof(EntityWithTypedId<>))
                .UseOverridesFromAssemblyOf<AutoPersistenceModelGenerator>();
        }

        #endregion

        private Action<IConventionFinder> GetConventions()
        {
            return c =>
            {
                c.Add<AutoPP.Data.NHibernateMaps.Conventions.ForeignKeyConvention>();
                c.Add<AutoPP.Data.NHibernateMaps.Conventions.HasManyConvention>();
                c.Add<AutoPP.Data.NHibernateMaps.Conventions.HasManyToManyConvention>();
                c.Add<AutoPP.Data.NHibernateMaps.Conventions.ManyToManyTableNameConvention>();
                c.Add<AutoPP.Data.NHibernateMaps.Conventions.PrimaryKeyConvention>();
                c.Add<AutoPP.Data.NHibernateMaps.Conventions.ReferenceConvention>();
                c.Add<AutoPP.Data.NHibernateMaps.Conventions.TableNameConvention>();
            };
        }
    }
}
