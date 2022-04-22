using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Data.Extensions
{
    public static class AsyncIQueryableExtensions
    {
        public static async Task<IList<T>> ToPagedListAsync<T>(this IQueryable<T> source)
        {
            var data = new List<T>(); 

            return new List<T>(data); 
        }
    }
}
