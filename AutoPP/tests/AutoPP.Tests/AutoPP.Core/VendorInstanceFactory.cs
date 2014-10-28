using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoPP.Core;

namespace Tests.AutoPP.Core
{
    public class VendorInstanceFactory
    {
        public static Vendor CreateValidVedndor()
        {
            return new Vendor()
            {
                Address = "No. 374/20, Temple Road,",
                City = "Thalawatugoda",
                Country = "Sri Lanka",
                Email = "wowarjuna@gmail.com",
                Fax = "0112773040",
                Phone = "0112773040",
                IsActive = true,
                Name = "Test Vendor",
                PostalCode = "10010",
                Mobile = "0776077809"
            };

        }
    }
}
