using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoPP.ApplicationServices;
using NUnit.Framework;
using AutoPP.Core;
using SharpArch.Core.PersistenceSupport;
using Rhino.Mocks;
using Tests.AutoPP.Core;
using SharpArch.Testing.NUnit;

namespace Tests.AutoPP.ApplicationServices.Impl
{
    [TestFixture]
    public class VendorServiceTests
    {
        private IVendorService _service;

        private IRepository<Vendor> _repository;
        
        [SetUp]
        public void SetUp()
        {
            ServiceLocatorInitializer.Init();
            _repository = MockRepository.GenerateMock<IRepository<Vendor>>();
            _repository.Stub(r => r.DbContext)
                .Return(MockRepository.GenerateMock<IDbContext>());
        }

        [Test]
        public void CanGetVendor()
        {
            // Establish Context
            Vendor _vendorObjToExpect = VendorInstanceFactory.CreateValidVedndor();
            _repository.Expect(r => r.Get(1)).Return(_vendorObjToExpect);

            // Act
            Vendor _vendorRetrieved =
                _service.Get(1);

            // Assert
            _vendorRetrieved.ShouldNotBeNull();
            _vendorRetrieved.ShouldEqual(_vendorObjToExpect);
                   
        }

        [Test]
        public void CanRegisterVendor()
        {
            Vendor _vendorObjToExpect = VendorInstanceFactory.CreateValidVedndor();

            _service.Register(_vendorObjToExpect);

            _repository.GetAll().Count.ShouldEqual(1);
        }
    }
}
