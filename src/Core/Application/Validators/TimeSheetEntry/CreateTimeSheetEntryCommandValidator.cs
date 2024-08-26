using FluentValidation;
using Application.Features.TimeSheetEntries.Commands;

namespace Application.Features.TimeSheetEntries.Validators
{
    public class CreateTimeSheetEntryCommandValidator : AbstractValidator<CreateTimeSheetEntryCommand>
    {
        public CreateTimeSheetEntryCommandValidator()
        {
            RuleFor(x => x.Date)
                .NotEmpty().WithMessage("Date is required.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Date cannot be in the future.");

            RuleFor(x => x.StartTime)
                .NotEmpty().WithMessage("Start Time is required.");

            RuleFor(x => x.EndTime)
                .NotEmpty().WithMessage("End Time is required.")
                .GreaterThan(x => x.StartTime).WithMessage("End Time must be after Start Time.");

            RuleFor(x => x.TotalHours)
                .NotEmpty().WithMessage("Total Hours is required.")
                .GreaterThanOrEqualTo(TimeSpan.Zero).WithMessage("Total Hours must be zero or greater.")
                .Equal(x => x.EndTime - x.StartTime).WithMessage("Total Hours must equal the difference between End Time and Start Time.");

            RuleFor(x => x.Description)
                .MaximumLength(1000).WithMessage("Description cannot exceed 1000 characters.");

            RuleFor(x => x.EmployeeId)
                .GreaterThan(0).WithMessage("Employee ID must be greater than zero.");
        }
    }
}
