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
        public Task<string> GetSeNameAsync<T>(T entity, int? languageId = null) where T : BaseEntity, ISlugSupported
        {
            bool returnDefaultValue = true;

            if (entity == null)
            {
                throw new ArgumentException(nameof(entity));    
            }

            var entityName = entity.GetType().Name;

            return await GetSeNameAsync(entity.Id, entityName ?? (await _workContext.GetWorkingLanguageAsync()).Id, returnDefaultValue);
        }
        public async Task<string> GetSeNameAsync<T>(int entityId, string entityName)
        {
            var result = string.Empty;
            var loadLocalizedValue = true;
            var returnDefaultValue = true;

            //localized value 
            if (loadLocalizedValue)
            {
                result = await GetActiveSlugAsync(entityId, entityName);
            }

            if (string.IsNullOrEmpty(result) && returnDefaultValue)
            {
                result = await GetActiveSlugAsync(entityId, entityName); 
            }

            return result;
        }

        public Task<string> GetSeNameAsync(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return Task.FromResult(name); 
            }

            var okChars = "asbcdefghijklmnopqrstuvwxyz1234567890 _-";
            name = name.Trim().ToLowerInvariant();

            if (convertNonWesterenChars && _seoCharacterTable == null)
            {
                InitializeSeoCharacterTable(); 
            }

            var sb = new StringBuilder();
            foreach (var c in name.ToCharArray())
            {
                var c2 = c.ToString();
                if (convertNonWesternChars)
                {
                    if (_seoCharacterTable?.ContainsKey(c2) ?? false)
                    {
                        c2 = _seoCharacterTable[c2].ToLowerInvariant();
                    }

                    if (allowUnicodeCharsInUrls)
                    {
                        if (char.IsLetterOrDigit(c) || okChars.Contains(c2))
                        {
                            sb.Append(c2);
                        }
                        else if (okChars.Contains(c2))  
                        {
                            sb.Append(c2); 
                        }
                    }

                    var name2 = sb.ToString();
                    name2 = name2.Replace(" ", "-"); 
                    while(name2.Contains("--"))
                    {
                        name2 = name2.Replace("--", "-"); 
                    }
                    while (name2.Contains("__"))
                    {
                        name2 = name2.Replace("__", "_"); 
                    }

                    return Task.FromResult(name2);
                }
            }
        }

    }
}
