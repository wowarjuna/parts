using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoPP.ApplicationServices.Util;

namespace AutoPP.ApplicationServices
{
    public interface IReportService
    {
        ReportResponse GetVisits(ReportRequest Request);
        ReportResponse GetVisitByMake(ReportRequest Request);
    }
}
