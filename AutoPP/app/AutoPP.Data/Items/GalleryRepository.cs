using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoPP.Core.RepositoryInterfaces;
using AutoPP.Core;
using SharpArch.Data.NHibernate;
using NHibernate.Criterion;

namespace AutoPP.Data.Items
{
    public class GalleryRepository : Repository<Gallery>, IGalleryRepository
    {
        #region IGalleryRepository Members

        public Gallery Get(Guid GalleryId)
        {
            return Session.CreateCriteria<Gallery>().Add(Restrictions.Eq("GalleryId", GalleryId)).UniqueResult<Gallery>(); 
        }

        #endregion
       
    }
}
