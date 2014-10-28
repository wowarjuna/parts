using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoPP.Core;

namespace AutoPP.ApplicationServices
{
    public interface IVendorService
    {
        void Register(Vendor vendor);
        IList<Vendor> AllVendors();
        Vendor Get(int Id);
        void Update(Vendor Vendor);
        void AddShipment(Shipment shipment);
        IList<Shipment> GetShipments(int vendorId);
        Shipment GetShipment(int shipmentId);
        void UpdateShipment(Shipment shipment);
    }
}
