﻿namespace TManager.util
{
    public class DateUtil
    {
        public static DateOnly Today()
        {
            return DateOnly.FromDateTime(DateTime.Now);
        }

        public static DateOnly Yesterday()
        {
            return Today().AddDays(-1);
        }

        public static DateOnly Tomorrow()
        {
            return Today().AddDays(1);
        }

        public static DateTime ToEndOfDay(DateOnly date)
        {
            return new DateTime(date, TimeOnly.MaxValue);
        }

        public static DateOnly Yesterday(DateOnly date)
        {
            return date.AddDays(-1);
        }

        public static DateOnly From(DateTime date)
        {
            return DateOnly.FromDateTime(date);
        }
    }
}
