using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Core.PersistenceSupport;

namespace AutoPP.Core.RepositoryInterfaces
{
    public interface ISearchRepository : IRepository<SearchItem>
    {
        IQueryable<SearchItem> GetItems(IDictionary<string, object> parameters, int startIndex, int offset, out int Count);
    }
}
