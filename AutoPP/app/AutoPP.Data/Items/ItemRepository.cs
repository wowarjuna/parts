using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoPP.Core.RepositoryInterfaces;
using AutoPP.Core;
using SharpArch.Data.NHibernate;
using NHibernate.Criterion;
using NHibernate;
using NHibernate.Linq;


namespace AutoPP.Data.Items
{
    public class ItemRepository : Repository<Item>,  IItemRepository
    {
        #region IItemRepository Members

        public IQueryable<Item> GetItems(Func<Item, bool> expression, int startIndex, int offset, out int Count)
        {
            var _query = Session.Query<Item>().Where(expression).OrderByDescending( x => x.ModifiedOn);
            
            Count = _query.Count<Item>();
            return _query.Skip(startIndex).Take(offset).AsQueryable<Item>();
        }

        public IQueryable<Item> GetItems()
        {
            return Session.Query<Item>().AsQueryable<Item>();
        }

        

        public IList<Item> GetItems(Dictionary<string, object> filters, int startIndex, int offset, out int Count)
        {
            
            ICriteria _criteria = Session.CreateCriteria<Item>();
            foreach(var _filter in filters)
            {
                if (_filter.Value.GetType() == typeof(int))
                    _criteria.Add(Restrictions.Eq(_filter.Key, _filter.Value));
                else
                    _criteria.Add(Restrictions.Like(_filter.Key, string.Format("%{0}%", _filter.Value)));
                
            }
                                  
            ICriteria _criteriaCount = (ICriteria)_criteria.Clone();
            Count = (int)_criteriaCount.SetProjection(Projections.Count("Id")).UniqueResult();

            return _criteria.SetFirstResult(startIndex).SetMaxResults(offset).List<Item>();
          
        }

        #endregion

        
    }
}
