using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoPP.ApplicationServices.Util;
using AutoPP.Core.RepositoryInterfaces;
using System.Collections;

namespace AutoPP.ApplicationServices.Impl
{
    public class ReportService : IReportService
    {
        private readonly IReportsRepository _repository;

        public ReportService(IReportsRepository _repository)
        {
            this._repository = _repository;
        }

        #region IReportService Members

        public ReportResponse GetVisits(ReportRequest Request)
        {
            ReportResponse _result = new ReportResponse();

            var _data = _repository.GetVisitsByVendor(Request.VendorId);
            foreach (var _item in _data)
            {
                object[] _row = _item as object[];
                _result.Add(_row[0].ToString(), _row[1]);
            }
               
            return _result;
        }

        public ReportResponse GetVisitByMake(ReportRequest Request)
        {
            ReportResponse _result = new ReportResponse();
            var _data = _repository.GetVisitsByMakeAndVendor(Request.VendorId, Request.Make);
            foreach (var _item in (IEnumerable)_data)
            {
                object[] _row = _item as object[];
                _result.Add(_row[0].ToString(), _row[1]);
            }

            return _result;
        }

        #endregion
    }
}
