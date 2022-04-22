using Nop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Data
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IList<TEntity>> GetAllPagedAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> func = null, bool includeDeleted = true);
    }
}
