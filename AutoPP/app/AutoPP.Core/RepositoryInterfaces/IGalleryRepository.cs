using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Core.PersistenceSupport;

namespace AutoPP.Core.RepositoryInterfaces
{
    public interface IGalleryRepository : IRepository<Gallery>
    {
        Gallery Get(Guid GalleryId);
    }
}
