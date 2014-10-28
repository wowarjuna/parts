using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Core.PersistenceSupport;

namespace AutoPP.Core.RepositoryInterfaces
{
    public interface IItemRepository : IRepository<Item>
    {
        IList<Item> GetItems(Dictionary<string, object> filters, int startIndex, int offset, out int Count);
        IQueryable<Item> GetItems(Func<Item, bool> expression, int startIndex, int offset, out int Count);
        IQueryable<Item> GetItems();
        

    }
}
