using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoPP.Core;
using FluentNHibernate.Automapping.Alterations;
using FluentNHibernate.Automapping;

namespace AutoPP.Data.NHibernateMaps
{
    public class RequestMaps : IAutoMappingOverride<Request>
    {

        #region IAutoMappingOverride<Request> Members

        public void Override(AutoMapping<Request> mapping)
        {
            mapping.Table("ItemRequests");
            mapping.Id(x => x.Id, "Id").UnsavedValue(0).GeneratedBy.Identity();
            mapping.Map(x => x.Name, "Name");
            mapping.Map(x => x.Description, "Description");
            mapping.References<User>(x => x.User).Column("UserId");
        }

        #endregion
    }

}
