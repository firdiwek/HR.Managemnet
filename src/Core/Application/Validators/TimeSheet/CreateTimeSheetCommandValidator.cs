using FluentValidation;
using Application.Features.TimeSheets.Commands;

namespace Application.Features.TimeSheets.Validators
{
    public class CreateTimeSheetCommandValidator : AbstractValidator<CreateTimeSheetCommand>
    {
        public CreateTimeSheetCommandValidator()
        {
            RuleFor(x => x.Date)
                .NotEmpty().WithMessage("Date is required.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Date cannot be in the future.");

            RuleFor(x => x.WorkedHours)
                .GreaterThanOrEqualTo(TimeSpan.Zero).WithMessage("Worked Hours must be zero or greater.");

            RuleFor(x => x.Notes)
                .MaximumLength(500).WithMessage("Notes cannot exceed 500 characters.");

            RuleFor(x => x.EmployeeId)
                .GreaterThan(0).WithMessage("Employee ID must be greater than zero.");
        }
    }
}
