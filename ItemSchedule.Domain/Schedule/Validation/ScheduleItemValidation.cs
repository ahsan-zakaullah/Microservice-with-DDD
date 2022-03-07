using ItemSchedule.Domain.Schedule.Models;
using System.ComponentModel.DataAnnotations;

namespace ItemSchedule.Domain.Schedule.Validation;

public static class ScheduleItemValidation
{
    public static void ValidateDoesNotOverlapWithItems(this ScheduleItem currentItem, List<ScheduleItem> scheduleItems)
    {
        if (scheduleItems.Any(scheduleItem => currentItem.Start < scheduleItem.End && scheduleItem.Start < currentItem.End))
        {
            throw new ValidationException("There is a conflict with the other planned item.");
        }
    }

    public static void ValidateDoesNotUpdateTwice(this ScheduleItem currentItem, List<ScheduleItem> scheduleItems)
    {
        if (scheduleItems.FirstOrDefault(x => x.NumberOfTimesUpdated == 0) == null)
        {
            throw new ValidationException("There is a conflict with the other planned item.");
        }
    }
}