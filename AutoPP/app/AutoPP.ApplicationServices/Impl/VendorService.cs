using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoPP.Core;
using SharpArch.Core.PersistenceSupport;

namespace AutoPP.ApplicationServices.Impl
{
    public class VendorService : IVendorService
    {
        private IRepository<Vendor> _rVendor;
        private IRepository<Shipment> _rShipment;

        public VendorService(IRepository<Vendor> rVendor, IRepository<Shipment> rShipment)
        {
            this._rVendor = rVendor;
            this._rShipment = rShipment;
        }

        #region IVendorService Members

        public void Register(Vendor vendor)
        {
            _rVendor.SaveOrUpdate(vendor);
            _rVendor.DbContext.CommitChanges();
        }

        public IList<Vendor> AllVendors()
        {
            return _rVendor.GetAll();
        }

        public Vendor Get(int Id)
        {
            return _rVendor.Get(Id);
        }

        public void Update(Vendor Vendor)
        {
            _rVendor.SaveOrUpdate(Vendor);
            _rVendor.DbContext.CommitChanges();
        }

        public void AddShipment(Shipment shipment)
        {
            _rShipment.SaveOrUpdate(shipment);
            _rShipment.DbContext.CommitChanges();
        }

        public IList<Shipment> GetShipments(int vendorId)
        {
            IDictionary<string,object> _params = new Dictionary<string,object>();
            var _vendor = _rVendor.Get(vendorId);
            _params.Add("Vendor", _vendor);
            return _rShipment.FindAll(_params).OrderByDescending(x => x.ShipmentDate).ToList<Shipment>();
        }

        public Shipment GetShipment(int shipmentId)
        {
            return _rShipment.Get(shipmentId);
        }

        public void UpdateShipment(Shipment shipment)
        {
            _rShipment.SaveOrUpdate(shipment);
            _rShipment.DbContext.CommitChanges();
        }

        #endregion
    }
}
