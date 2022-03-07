using FluentValidation;
using ItemSchedule.Dto.Input;

namespace ItemSchedule.Validators
{
    public class ScheduleInputItemDtoValidator : AbstractValidator<ScheduleInputItemDto>
    {
        public ScheduleInputItemDtoValidator()
        {
            RuleFor(x => x.Start).NotNull().WithMessage("start date field should not be empty");
            RuleFor(x => x.End).NotNull().WithMessage("End date should not be empty");
        }
    }
}
