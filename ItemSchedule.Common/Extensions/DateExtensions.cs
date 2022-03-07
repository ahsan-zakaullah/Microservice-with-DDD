namespace ItemSchedule.Common.Extensions;

public static class DateExtensions
{
    public static string ToIso8601(this DateTime value)
    {
        return value.ToString("yyyy-MM-ddTHH:mm:ssZ");
    }}