using FluentValidation;
using Application.Features.Attendance.Commands;

namespace Application.Features.Attendance.Validators
{
    public class UpdateAttendanceCommandValidator : AbstractValidator<UpdateAttendanceCommand>
    {
        public UpdateAttendanceCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("ID must be a positive number.");

            RuleFor(x => x.Date)
                .NotEmpty().WithMessage("Date is required.")
                .Must(date => date.Date <= DateTime.Now.Date).WithMessage("Date cannot be in the future.");

            RuleFor(x => x.ClockInTime)
                .NotEmpty().WithMessage("Clock-in time is required.")
                .LessThan(x => x.ClockOutTime).WithMessage("Clock-in time must be before clock-out time.");

            RuleFor(x => x.ClockOutTime)
                .NotEmpty().WithMessage("Clock-out time is required.");

            RuleFor(x => x.BreakStartTime)
                .LessThan(x => x.BreakEndTime).When(x => x.BreakEndTime.HasValue)
                .WithMessage("Break start time must be before break end time.");

            RuleFor(x => x.BreakEndTime)
                .GreaterThan(x => x.BreakStartTime).When(x => x.BreakStartTime.HasValue)
                .WithMessage("Break end time must be after break start time.");

            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("Status is required.")
                .Must(status => status == "Present" || status == "Absent" || status == "On Leave").WithMessage("Status must be 'Present', 'Absent', or 'On Leave'.");
        }
    }
}
