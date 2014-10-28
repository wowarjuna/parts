using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolrNet;
using System.Linq.Expressions;

namespace AutoPP.Web.Controllers.Helpers
{
    public static class IReadOnlyMappingManagerExtensions
    {
        public static string FieldName<T>(this IReadOnlyMappingManager mapper, Expression<Func<T, object>> property)
        {
            var propertyName = property.MemberName();
            return mapper.GetFields(typeof(T)).First(p => p.Property.Name == propertyName).FieldName;
        }
    }
}
