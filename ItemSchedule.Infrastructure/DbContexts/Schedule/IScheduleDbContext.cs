using ItemSchedule.Domain.Schedule.Models;
using Microsoft.EntityFrameworkCore;

namespace ItemSchedule.Infrastructure.DbContexts.Schedule;

public interface IScheduleDbContext : IDbContext
{
    DbSet<Domain.Schedule.Models.Schedule> Schedules { get; set; }

    DbSet<ScheduleItem> ScheduleItems { get; set; }
}