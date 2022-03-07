using ItemSchedule.Domain.Schedule.Models;
using ItemSchedule.Domain.Schedule.Repositories;
using ItemSchedule.Dto.Input;
using ItemSchedule.Dto.Response;
using ItemSchedule.Extensions;
using ItemSchedule.Infrastructure.DbContexts.Schedule;
using ItemSchedule.Services.Interfaces;

namespace ItemSchedule.Services;

public class SchedulesService : ServiceBase<IScheduleDbContext>, IScheduleService
{
    private readonly IScheduleRepository _scheduleRepository;
    private static object myLock = new();

    public SchedulesService(IScheduleDbContext dbContext, IScheduleRepository scheduleRepository) : base(dbContext)
    {
        _scheduleRepository = scheduleRepository;
    }

    public async Task<ScheduleResponseDto> GetLatestScheduleForPlant(int plantCode)
    {
        var currentDraftSchedule = await _scheduleRepository.GetLastUpdatedScheduleForPlant(plantCode);
        if (currentDraftSchedule == null)
        {
            throw new Exception($"There is no draft schedule for plant {plantCode}");
        }

        return currentDraftSchedule.MapToScheduleDto();
    }

    public async Task<ScheduleResponseDto> AddItemToSchedule(int scheduleId, ScheduleInputItemDto scheduleItem)
    {
        Schedule scheduleWithId;
        lock (myLock)
        {
            scheduleWithId = _scheduleRepository.GetScheduleById(scheduleId).Result;
            scheduleWithId.AddItem(
                start: scheduleItem.Start,
                end: scheduleItem.End,
                cementType: scheduleItem.CementType,
                now: DateTime.UtcNow);
            _scheduleRepository.Update(scheduleWithId).GetAwaiter().GetResult();
        }

        return scheduleWithId.MapToScheduleDto();
    }

    public async Task<ScheduleResponseDto> AddNewSchedule(int plantCode, List<ScheduleInputItemDto> scheduleInputItems)
    {
        var now = DateTime.UtcNow;
        var schedule = new Schedule(plantCode, now);
        if (scheduleInputItems != null)
        {
            foreach (var scheduleInputScheduleItem in scheduleInputItems)
            {
                schedule.AddItem(
                    start: scheduleInputScheduleItem.Start,
                    end: scheduleInputScheduleItem.End,
                    cementType: scheduleInputScheduleItem.CementType,
                    now: now);
            }
        }

        await _scheduleRepository.Insert(schedule);
        return schedule.MapToScheduleDto();
    }

    public async Task<ScheduleResponseDto> ChangeScheduleItem(int scheduleId, int itemId, ScheduleInputItemDto scheduleInputItem)
    {
        Schedule schedule;
        lock (myLock)
        {
            var now = DateTime.UtcNow;
            schedule = _scheduleRepository.GetScheduleById(scheduleId).Result;
            schedule.UpdateItem(itemId, scheduleInputItem.Start, scheduleInputItem.End, scheduleInputItem.CementType, now);
            _scheduleRepository.Update(schedule).GetAwaiter().GetResult();
            return schedule.MapToScheduleDto();
        }

    }
}