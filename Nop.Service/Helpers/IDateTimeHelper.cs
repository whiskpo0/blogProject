using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Service.Helpers
{
    public interface IDateTimeHelper
    {
        /// <summary>
        /// Converts the date and time to current user date and time
        /// </summary>
        /// <param name="dt">The date and time (represents local system time or UTC time) to convert.</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains a DateTime value that represents time that corresponds to the dateTime parameter in customer time zone.
        /// </returns>
        Task<DateTime> ConvertToUserTimeAsync(DateTime dt);

        /// <summary>
        /// Converts the date and time to current user date and time
        /// </summary>
        /// <param name="dt">The date and time (represents local system time or UTC time) to convert.</param>
        /// <param name="sourceDateTimeKind">The source datetimekind</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains a DateTime value that represents time that corresponds to the dateTime parameter in customer time zone.
        /// </returns>
        Task<DateTime> ConvertToUserTimeAsync(DateTime dt, DateTimeKind sourceDateTimeKind);

    }
}
