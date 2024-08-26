using FluentValidation;
using Application.Features.LeaveRequests.Commands;

namespace Application.Features.LeaveRequests.Validators
{
    public class UpdateLeaveRequestCommandValidator : AbstractValidator<UpdateLeaveRequestCommand>
    {
        public UpdateLeaveRequestCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("ID must be a positive number.");

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

            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("Status is required.")
                .Must(status => status == "Pending" || status == "Approved" || status == "Rejected").WithMessage("Status must be 'Pending', 'Approved', or 'Rejected'.");

            RuleFor(x => x.Comments)
                .MaximumLength(500).WithMessage("Comments cannot exceed 500 characters.");
        }
    }
}
