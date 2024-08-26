using FluentValidation;
using Application.Features.WorkSchedules.Commands;
using System.Linq;

namespace Application.Features.WorkSchedules.Validators
{
    public class CreateWorkScheduleCommandValidator : AbstractValidator<CreateWorkScheduleCommand>
    {
        public CreateWorkScheduleCommandValidator()
        {
            RuleFor(x => x.StartDate)
                .NotEmpty().WithMessage("Start Date is required.")
                .LessThan(x => x.EndDate).WithMessage("Start Date must be before End Date.");

            RuleFor(x => x.EndDate)
                .NotEmpty().WithMessage("End Date is required.")
                .GreaterThan(x => x.StartDate).WithMessage("End Date must be after Start Date.");

            RuleFor(x => x.ShiftType)
                .NotEmpty().WithMessage("Shift Type is required.")
                .Must(type => new[] { "Morning", "Afternoon", "Night" }.Contains(type)).WithMessage("Invalid Shift Type.");

            RuleFor(x => x.EmployeeId)
                .GreaterThan(0).WithMessage("Employee ID must be greater than zero.");

            RuleFor(x => x.WorkScheduleEntries)
                .NotEmpty().WithMessage("At least one Work Schedule Entry is required.")
                .Must(entries => entries.GroupBy(e => e.Date).All(g => g.Count() == 1))
                .WithMessage("Duplicate entries for the same date are not allowed.");

            RuleForEach(x => x.WorkScheduleEntries)
                .ChildRules(entries =>
                {
                    entries.RuleFor(x => x.Date)
                        .NotEmpty().WithMessage("Date is required.")
                        .GreaterThanOrEqualTo(DateTime.Now.Date).WithMessage("Date cannot be in the past.");

                    entries.RuleFor(x => x.StartTime)
                        .NotEmpty().WithMessage("Start Time is required.");

                    entries.RuleFor(x => x.EndTime)
                        .NotEmpty().WithMessage("End Time is required.")
                        .GreaterThan(x => x.StartTime).WithMessage("End Time must be after Start Time.");

                    entries.RuleFor(x => x.ShiftType)
                        .NotEmpty().WithMessage("Shift Type is required.")
                        .Must(type => new[] { "Morning", "Afternoon", "Night" }.Contains(type)).WithMessage("Invalid Shift Type.");
                });
        }
    }
}
