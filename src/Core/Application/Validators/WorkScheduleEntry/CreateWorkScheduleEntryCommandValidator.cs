using FluentValidation;
using Application.Features.WorkScheduleEntries.Commands;
using System;

namespace Application.Features.WorkScheduleEntries.Validators
{
    public class CreateWorkScheduleEntryCommandValidator : AbstractValidator<CreateWorkScheduleEntryCommand>
    {
        public CreateWorkScheduleEntryCommandValidator()
        {
            RuleFor(x => x.WorkScheduleId)
                .GreaterThan(0).WithMessage("WorkSchedule ID must be greater than zero.");

            RuleFor(x => x.Date)
                .NotEmpty().WithMessage("Date is required.")
                .GreaterThan(DateTime.Now.Date.AddDays(-1)).WithMessage("Date cannot be in the past.");

            RuleFor(x => x.StartTime)
                .NotEmpty().WithMessage("Start Time is required.");

            RuleFor(x => x.EndTime)
                .NotEmpty().WithMessage("End Time is required.")
                .GreaterThan(x => x.StartTime).WithMessage("End Time must be after Start Time.");

            RuleFor(x => x.ShiftType)
                .NotEmpty().WithMessage("Shift Type is required.")
                .Must(type => new[] { "Morning", "Evening", "Night" }.Contains(type)).WithMessage("Invalid Shift Type.");
        }
    }
}
