using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolrNet;
using Microsoft.Practices.ServiceLocation;
using System.Web.Mvc;

namespace AutoPP.Web.Controllers.Helpers
{
    public static class HtmlHelperMapperExtensions
    {
        private static IReadOnlyMappingManager mapper
        {
            get { return ServiceLocator.Current.GetInstance<IReadOnlyMappingManager>(); }
        }

        public static string SolrFieldPropName<T>(this HtmlHelper helper, string fieldName)
        {
            var _field = from _f in   mapper.GetFields(typeof(T))
                         where _f.FieldName.Equals(fieldName)
                             select _f.Property.Name;
            //return mapper.GetFields(typeof(T)).First(p => p.FieldName == fieldName).Property.Name;
            return _field.First<string>();
        }
    }
}
