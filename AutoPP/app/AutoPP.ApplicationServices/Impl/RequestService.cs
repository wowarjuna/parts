using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoPP.Core;
using SharpArch.Core.PersistenceSupport;
using AutoPP.ApplicationServices.Util;
using System.ServiceModel.Activation;

namespace AutoPP.ApplicationServices.Impl
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class RequestService : IRequestService
    {
        private IRepository<Request> _repository;
        private IRepository<User> _rUser;
               
        public RequestService(IRepository<Request> repository, IRepository<User> rUser)
        {
            _repository = repository;
            _rUser = rUser;
        }

        #region IRequestService Members

        public void Add(Request Request)
        {
            _repository.SaveOrUpdate(Request);
        }

        public CustomerRequestResponse GetRequests(CustomerRequestParam request)
        {
            IDictionary<string, object> _params = new Dictionary<string,object>();
            _params.Add("User.UserId", Guid.Parse(request.UserId));
            CustomerRequestResponse _response = new CustomerRequestResponse();
            var _data = _repository.FindAll(_params).ToList<Request>();
            _response.Count = _data.Count;
            _response.Data = _data.AsEnumerable().Skip(request.StartFrom).Take(request.Offset).ToList();
            return _response;
            //return _repository.GetAll().Where(x => x.User.UserName.Equals("wowarjuna")).ToList<Request>();
        }

        public CustomerRequestResponse GetAllRequest(CustomerRequestParam request)
        {
            CustomerRequestResponse _response = new CustomerRequestResponse();
            var _data = _repository.GetAll();
            _response.Count = _data.Count;
            _response.Data = _data.AsEnumerable().OrderByDescending( x => x.ModifiedOn).Skip(request.StartFrom).Take(request.Offset).ToList();
            return _response;
        }

        public Request Get(int Id)
        {
            return _repository.Get(Id);
        }

        #endregion
    }
}
