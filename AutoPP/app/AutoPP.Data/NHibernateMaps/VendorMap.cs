using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Automapping.Alterations;
using AutoPP.Core;
using FluentNHibernate.Automapping;

namespace AutoPP.Data.NHibernateMaps
{
    public class VendorMap : IAutoMappingOverride<Vendor>
    {
        #region IAutoMappingOverride<Vendor> Members

        public void Override(AutoMapping<Vendor> mapping)
        {
            mapping.Table("Vendors");
            mapping.Id(x => x.Id, "Id").UnsavedValue(0).GeneratedBy.Identity();
            mapping.Map(x => x.Name, "Name");
            mapping.Map(x => x.Address, "Address");
            mapping.Map(x => x.City, "City");
            mapping.Map(x => x.PostalCode, "PostalCode");
            mapping.Map(x => x.Country, "Country");
            mapping.Map(x => x.Phone, "Phone");
            mapping.Map(x => x.Mobile, "Mobile");
        }

        #endregion
    }
}
