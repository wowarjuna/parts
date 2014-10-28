using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoPP.Core;
using System.ServiceModel;
using AutoPP.ApplicationServices.Util;
using System.ServiceModel.Web;
using System.ServiceModel.Activation;

namespace AutoPP.ApplicationServices
{
    [ServiceContract]
    public interface IRequestService
    {
        void Add(Request Request);

        [OperationContract]
        [WebGet]
        CustomerRequestResponse GetRequests(CustomerRequestParam request);
        CustomerRequestResponse GetAllRequest(CustomerRequestParam request);
        Request Get(int Id);
    }
}
