using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Core.PersistenceSupport;
using System.Collections;

namespace AutoPP.Core.RepositoryInterfaces
{
    public interface IReportsRepository : IRepository<Item>
    {
        IList GetVisitsByVendor(int VendorId);
        IList GetVisitsByMakeAndVendor(int VendorId, int Make);

    }
}
