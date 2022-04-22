using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Service.Helpers
{
    public class DateTimeHelper : IDateTimeHelper
    {
        public async Task<DateTime> ConvertToUserTimeAsync(DateTime dt)
        {
            return await ConvertToUserTimeAsync(dt, dt.Kind); 
        }

        public async Task<DateTime> ConvertToUserTimeAsync(DateTime dt, DateTimeKind sourceDateTimeKind)
        {
            dt = DateTime.SpecifyKind(dt, sourceDateTimeKind);
            if (sourceDateTimeKind == DateTimeKind.Local && TimeZoneInfo.Local.IsInvalidTime(dt))   
            {
                return dt; 
            }

            var currentUserTimeZoneInfo = await GetCurrentTimeZoneAsync();
            return TimeZoneInfo.ConvertTime(dt, currentUserTimeZoneInfo); 
        }

        public async Task<TimeZoneInfo> GetCurrentTimeZoneAsync()
        {
            return null;  //await GetCurrentTimeZoneAsync(await _workContext.GetCurrentCustomerAsync()); 
        }
    }
}
