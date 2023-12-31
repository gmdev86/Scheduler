using System;

namespace Scheduler.Core.Utility
{
    public class DateTimeConverter
    {
        public static DateTime UtcToLocalDateTime(DateTime utcDateTime)
        {
            return utcDateTime.ToLocalTime();
        }

        public static DateTime DateTimeOffsetToUtc(DateTime localDateTime)
        {
            TimeZoneInfo userTimeZone = TimeZoneInfo.Local;
            DateTimeOffset utcDateTimeOffset = new DateTimeOffset(localDateTime, userTimeZone.GetUtcOffset(localDateTime));
            return utcDateTimeOffset.UtcDateTime;
        }
    }
}
