using Nop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Data
{
    public class EntityRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        public async Task<IList<TEntity>> GetAllPagedAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> func = null, bool includeDeleted)
        {
            var query = AddDeletedFilter(Table, includeDeleted);

            query = func != null ? func(query) : query; 

            return await query.ToPagedListAsync();
        }

        protected IQueryable<TEntity> AddDeletedFilter(IQueryable<TEntity> query, in bool includeDeleted)
        {
            if (includeDeleted)
            {
                return query; 
            }

            if (typeof(TEntity).GetInterface(nameof(ISoftDeletedEntity)) == null)
            {
                return query;
            }

            return query.OfType<ISoftDeletedEntity>().Where(entry => !entry.Delted).OfType<TEntity>(); 
        }

        public IQueryable<TEntity> Table => _dataProvider.GetTable<TEntity>(); 
    }
}
