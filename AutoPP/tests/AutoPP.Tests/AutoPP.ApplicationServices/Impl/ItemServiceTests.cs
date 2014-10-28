using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using AutoPP.ApplicationServices;
using AutoPP.ApplicationServices.Impl;
using AutoPP.Core.RepositoryInterfaces;
using Rhino.Mocks;
using SharpArch.Core.PersistenceSupport;

namespace Tests.AutoPP.ApplicationServices.Impl
{
    [TestFixture]
    public class ItemServiceTests
    {
        private IItemsService _service;

        private IItemRepository _repository;

        [SetUp]
        public void SetUp()
        {
            ServiceLocatorInitializer.Init();
            _repository = MockRepository.GenerateMock<IItemRepository>();
            _repository.Stub(r => r.DbContext)
                .Return(MockRepository.GenerateMock<IDbContext>());
        }

        [Test]
        public void CanGetItem()
        {
        }
    }
}
