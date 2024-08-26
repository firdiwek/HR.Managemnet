using FluentValidation;
using Application.Features.Departments.Commands;

namespace Application.Features.Departments.Validators
{
    public class UpdateDepartmentCommandValidator : AbstractValidator<UpdateDepartmentCommand>
    {
        public UpdateDepartmentCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Department ID must be a positive number.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(1, 100).WithMessage("Name must be between 1 and 100 characters.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .Length(1, 500).WithMessage("Description must be between 1 and 500 characters.");

            RuleFor(x => x.Budget)
                .GreaterThan(0).WithMessage("Budget must be a positive number.");
        }
    }
}
