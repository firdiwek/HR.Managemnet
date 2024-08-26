using FluentValidation;
using Application.Features.Payrolls.Commands;

namespace Application.Features.Payrolls.Validators
{
    public class CreatePayrollCommandValidator : AbstractValidator<CreatePayrollCommand>
    {
        public CreatePayrollCommandValidator()
        {
            RuleFor(x => x.BasicSalary)
                .GreaterThanOrEqualTo(0).WithMessage("Basic Salary must be zero or greater.");

            RuleFor(x => x.Allowances)
                .GreaterThanOrEqualTo(0).WithMessage("Allowances must be zero or greater.");

            RuleFor(x => x.Deductions)
                .GreaterThanOrEqualTo(0).WithMessage("Deductions must be zero or greater.");

            RuleFor(x => x.PayDate)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Pay Date cannot be in the future.");

            RuleFor(x => x.EmployeeId)
                .GreaterThan(0).WithMessage("Employee ID must be greater than zero.");
        }
    }
}
