using Nop.Core;
using Nop.Core.Domain.Seo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Service.Seo
{
    public interface IUrlRecordService
    {
        Task<string> GetSeNameAsync<T>(T entity, int? languageId = null) where T : BaseEntity, ISlugSupported;
        Task<string> GetSeNameAsync<T>(int entityId, string entityName);
        Task<string> GetSeNameAsync(string name);
    }
}
