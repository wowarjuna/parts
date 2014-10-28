using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoPP.Core;
using SharpArch.Data.NHibernate;
using AutoPP.Core.RepositoryInterfaces;
using System.Collections;
using NHibernate.Linq;

namespace AutoPP.Data.Reports
{
    public class ReportsRepository : Repository<Item>, IReportsRepository
    {

        #region IReportsRepository Members

        public IList GetVisitsByVendor(int VendorId)
        {
            return Session.CreateSQLQuery(string.Format(@"select m.Name, SUM(i.NoOfHits) from Items i inner join Make m 
                            on i.Make = m.Id
                            where VendorId = {0}
                            group by Make, m.Name", VendorId)).List();
        }

        public IList GetVisitsByMakeAndVendor(int VendorId, int Make)
        {
            return Session.CreateSQLQuery(string.Format(@"select m.Name, SUM(i.NoOfHits) from Items i inner join dbo.ItemsInModels im
                            on im.ItemId = i.Id inner join Models m
                            on im.ModelId = m.Id
                            where VendorId = {0} and m.Make = {1}
                            group by m.Make, m.Name", VendorId, Make)).List();
        }

        #endregion
    }
}
