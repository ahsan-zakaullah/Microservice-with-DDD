using ItemSchedule.Domain.Common.Repository;

namespace ItemSchedule.Domain.Schedule.Repositories;

public interface IScheduleRepository: IGenericRepository<Models.Schedule>
{

    public Task<Models.Schedule> GetLastUpdatedScheduleForPlant(int plantCode); 
    public Task<Models.Schedule> GetScheduleById(int scheduleId);
    
}