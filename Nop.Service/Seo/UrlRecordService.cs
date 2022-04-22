using Nop.Core;
using Nop.Core.Domain.Seo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Service.Seo
{
    public class UrlRecordService : IUrlRecordService
    {
        public Task<string> GetSeNameAsync<T>(T entity) where T : BaseEntity, ISlugSupported
        {
            throw new NotImplementedException();
        }

        public Task<string> GetSeNameAsync<T>(int entityId, string entityName)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetSeNameAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}
