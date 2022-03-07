using ItemSchedule.Dto.Input;
using ItemSchedule.Dto.Response;

namespace ItemSchedule.Services.Interfaces;

public interface IScheduleService
{
    public Task<ScheduleResponseDto> GetLatestScheduleForPlant(int plantCode);
    public Task<ScheduleResponseDto> AddItemToSchedule(int scheduleId, ScheduleInputItemDto scheduleItem);
    public Task<ScheduleResponseDto> AddNewSchedule(int plantCode, List<ScheduleInputItemDto> scheduleInput);
    public Task<ScheduleResponseDto> ChangeScheduleItem(int scheduleId, int itemId, ScheduleInputItemDto scheduleInputItem);
}