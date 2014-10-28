using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoPP.Core;
using FluentNHibernate.Automapping.Alterations;
using FluentNHibernate.Automapping;

namespace AutoPP.Data.NHibernateMaps
{
    public class UserMap : IAutoMappingOverride<User>
    {
        #region IAutoMappingOverride<User> Members

        public void Override(AutoMapping<User> mapping)
        {
            mapping.Table("aspnet_Users");
            mapping.IgnoreProperty(x => x.Id);
            mapping.Id(x => x.UserId, "UserId").GeneratedBy.GuidComb().UnsavedValue(new Guid());
            mapping.Map(x => x.UserName, "UserName");
            mapping.IgnoreProperty(x => x.Password);
            mapping.IgnoreProperty(x => x.ConfirmPassword);
        }

        #endregion
    }
}
