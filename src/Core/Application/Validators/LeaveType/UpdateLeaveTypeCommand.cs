using FluentValidation;
using Application.Features.LeaveTypes.Commands;

namespace Application.Features.LeaveTypes.Validators
{
    public class UpdateLeaveTypeCommandValidator : AbstractValidator<UpdateLeaveTypeCommand>
    {
        public UpdateLeaveTypeCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("ID must be a positive number.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");

            RuleFor(x => x.MaxDays)
                .GreaterThan(0).WithMessage("MaxDays must be greater than 0.");
        }
    }
}
