using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoPP.Core;
using FluentNHibernate.Automapping.Alterations;
using FluentNHibernate.Automapping;

namespace AutoPP.Data.NHibernateMaps
{
    public class ShipmentMap : IAutoMappingOverride<Shipment>
    {
        public void Override(AutoMapping<Shipment> mapping)
        {
            mapping.Table("Shipments");
            mapping.Id(x => x.Id, "Id").UnsavedValue(0).GeneratedBy.Identity();
            mapping.Map(x => x.ShipmentDate, "ShipmentDate");
            mapping.References<Vendor>(x => x.Vendor).Column("Vendor");
        }
    }
}
