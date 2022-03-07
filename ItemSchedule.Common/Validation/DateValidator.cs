using ItemSchedule.Common.Extensions;
using System.ComponentModel.DataAnnotations;

namespace ItemSchedule.Common.Validation;

public static class DateValidator
{
    public static void ValidateRange(DateTime start, DateTime end)
    {
        if (start >= end)
        {
            throw new ValidationException($"Date range must consist of a start ({start.ToIso8601()}) and end ({end.ToIso8601()}) date where start is < end");
        }
    }
}