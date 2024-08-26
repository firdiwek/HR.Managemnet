using FluentValidation;
using Application.Features.Employees.Requests.Command;

namespace Application.Features.Employees.Validators
{
    public class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
    {
        public UpdateEmployeeCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Employee ID must be a positive number.");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .Length(1, 50).WithMessage("First name must be between 1 and 50 characters.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .Length(1, 50).WithMessage("Last name must be between 1 and 50 characters.");

            RuleFor(x => x.DateOfBirth)
                .NotEmpty().WithMessage("Date of birth is required.")
                .Must(date => date < DateTime.Now).WithMessage("Date of birth must be in the past.");

            RuleFor(x => x.Gender)
                .NotEmpty().WithMessage("Gender is required.")
                .Must(g => g == "Male" || g == "Female" || g == "Other").WithMessage("Gender must be 'Male', 'Female', or 'Other'.");

            RuleFor(x => x.EmailAddress)
                .NotEmpty().WithMessage("Email address is required.")
                .EmailAddress().WithMessage("Email address must be valid.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^\+?\d{10,15}$").WithMessage("Phone number must be between 10 and 15 digits.");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address is required.")
                .Length(1, 200).WithMessage("Address must be between 1 and 200 characters.");

            RuleFor(x => x.DepartmentId)
                .GreaterThan(0).WithMessage("Department ID must be a positive number.");

            RuleFor(x => x.JobTitle)
                .NotEmpty().WithMessage("Job title is required.")
                .Length(1, 100).WithMessage("Job title must be between 1 and 100 characters.");

            RuleFor(x => x.ManagerId)
                .GreaterThan(0).When(x => x.ManagerId.HasValue).WithMessage("Manager ID must be a positive number if specified.");

            RuleFor(x => x.HireDate)
                .NotEmpty().WithMessage("Hire date is required.")
                .Must(date => date >= DateTime.Now.AddMonths(-6)).WithMessage("Hire date must be within the last 6 months.");

            RuleFor(x => x.EmploymentStatus)
                .NotEmpty().WithMessage("Employment status is required.")
                .Must(status => status == "Active" || status == "Inactive" || status == "On Leave").WithMessage("Employment status must be 'Active', 'Inactive', or 'On Leave'.");

            RuleFor(x => x.ContractType)
                .NotEmpty().WithMessage("Contract type is required.")
                .Must(type => type == "Full-Time" || type == "Part-Time" || type == "Contract").WithMessage("Contract type must be 'Full-Time', 'Part-Time', or 'Contract'.");

            RuleFor(x => x.Salary)
                .GreaterThan(0).WithMessage("Salary must be a positive number.");
        }
    }
}
