using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorMvc.Utilities
{
    public static class DateTimeConverter
    {
        public static DateTime ConvertEpochToDatetime(long ticks)
        {
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(ticks);
            DateTime dateTime = dateTimeOffset.UtcDateTime;
            return dateTime;
        }
    }
}
