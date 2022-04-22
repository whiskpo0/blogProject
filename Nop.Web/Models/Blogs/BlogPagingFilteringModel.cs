using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nop.Web.Models.Blogs
{
    public class BlogPagingFilteringModel
    {
        public DateTime? GetParsedMonth()
        {
            DateTime? result = null;
            if (!string.IsNullOrEmpty(Month))   
            {
                var tempDate = Month.Split(new[] { '-' });
                if (tempDate.Length == 2)
                {
                    result = new DateTime(Convert.ToInt32(tempDate[0]), Convert.ToInt32(tempDate[1]), 1);
                }
            }
            return result; 
        }

        public  DateTime? GetFromMonth()
        {
            var filterByMonth = GetParsedMonth(); 
            if(filterByMonth.HasValue)
            {
                return filterByMonth.Value;
            }
            return null; 
        }

        public DateTime? GetToMonth()
        {
            var filterByMonth = GetParsedMonth();
            if (filterByMonth.HasValue)
            {
                return filterByMonth.Value.AddMonths(1).AddSeconds(-1);
            }
            return null; 
        }

        public string Month { get; set; }
        public string Tag { get; set; }
    }
}
