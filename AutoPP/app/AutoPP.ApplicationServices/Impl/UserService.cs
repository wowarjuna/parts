using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoPP.Core;
using SharpArch.Core.PersistenceSupport;

namespace AutoPP.ApplicationServices.Impl
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> UserRepository)
        {
            _userRepository = UserRepository;
        }

        #region IUserService Members

        public User GetUser(string Id)
        {
            Dictionary<string, object> _criteria = new Dictionary<string, object>();
            _criteria.Add("UserId", Guid.Parse(Id));
            return _userRepository.FindOne(_criteria);
        }

        #endregion
    }
}
