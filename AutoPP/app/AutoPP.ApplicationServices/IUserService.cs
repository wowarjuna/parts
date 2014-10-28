using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoPP.Core;

namespace AutoPP.ApplicationServices
{
    public interface IUserService
    {
        User GetUser(string Id);
    }
}
