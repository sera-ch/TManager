namespace TManager.util
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

        public static DateTime ToEndOfDay(DateOnly date)
        {
            return new DateTime(date, TimeOnly.MaxValue);
        }
    }
}
