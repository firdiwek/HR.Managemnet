using FluentValidation;
using Application.Features.LeaveRequests.Commands;

namespace Application.Features.LeaveRequests.Validators
{
    public class CreateLeaveRequestCommandValidator : AbstractValidator<CreateLeaveRequestCommand>
    {
        public CreateLeaveRequestCommandValidator()
        {
            RuleFor(x => x.LeaveType)
                .NotEmpty().WithMessage("Leave type is required.")
                .Must(leaveType => leaveType == "Sick" || leaveType == "Vacation" || leaveType == "Other").WithMessage("Leave type must be 'Sick', 'Vacation', or 'Other'.");

            RuleFor(x => x.StartDate)
                .NotEmpty().WithMessage("Start date is required.")
                .LessThan(x => x.EndDate).WithMessage("Start date must be before end date.")
                .Must(startDate => startDate.Date >= DateTime.Now.Date).WithMessage("Start date cannot be in the past.");

            RuleFor(x => x.EndDate)
                .NotEmpty().WithMessage("End date is required.")
                .GreaterThan(x => x.StartDate).WithMessage("End date must be after start date.");

            RuleFor(x => x.Comments)
                .MaximumLength(500).WithMessage("Comments cannot exceed 500 characters.");

            RuleFor(x => x.EmployeeId)
                .GreaterThan(0).WithMessage("Employee ID must be a positive number.");
        }
    }
}
