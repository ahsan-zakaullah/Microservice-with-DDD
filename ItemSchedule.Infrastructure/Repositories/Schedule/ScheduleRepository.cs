using ItemSchedule.Domain.Schedule.Repositories;
using ItemSchedule.Infrastructure.DbContexts.Schedule;
using Microsoft.EntityFrameworkCore;

namespace ItemSchedule.Infrastructure.Repositories.Schedule;

public class ScheduleRepository: GenericRepository<Domain.Schedule.Models.Schedule>, IScheduleRepository
{
    public ScheduleRepository(IScheduleDbContext context) : base(context)
    {
    }

    public Task<Domain.Schedule.Models.Schedule> GetLastUpdatedScheduleForPlant(int plantCode)
    {
        return FindByInclude(it => it.PlantCode == plantCode, it => it.ScheduleItems)
            .OrderByDescending(it => it.UpdatedOn)
            .SingleAsync();
    }

    public async Task<Domain.Schedule.Models.Schedule> GetScheduleById(int scheduleId)
    {
        return await FindByInclude(it => it.ScheduleId == scheduleId, it => it.ScheduleItems).SingleAsync();
    }
}