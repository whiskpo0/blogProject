using Nop.Core;
using Nop.Core.Domain.Common;
using Nop.Data.DbContexts;
using Nop.Data.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nop.Data
{

    public class EntityRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {

        private readonly CoreDbContexts _dataProvider; 

        public EntityRepository()
        {
            
        }
        public async Task<IList<TEntity>> GetAllPagedAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> func = null, bool includeDeleted = true)
        {
            var query = AddDeletedFilter(Table, includeDeleted);

            query = func != null ? func(query) : query; 

            return await query.ToPagedListAsync();
            
        }

        public async Task<IList<TEntity>> GetAllPagedAsync(Func<IQueryable<TEntity>, Task<IQueryable<TEntity>>> func = null, bool includeDeleted = true)
        {
            var query = AddDeletedFilter(Table, includeDeleted);

            query = func != null ? await func(query) : query;

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

            return query.OfType<ISoftDeletedEntity>().Where(entry => !entry.Deleted).OfType<TEntity>(); 
        }

        public IQueryable<TEntity> Table; //=> _dataProvider.GetTable<TEntity>(); 
    }
}
