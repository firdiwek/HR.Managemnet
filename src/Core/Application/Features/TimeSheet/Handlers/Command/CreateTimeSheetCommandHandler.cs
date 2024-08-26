using Application.Contracts.Persistance;
using Application.Features.TimeSheets.Commands;
using Domain;
using MediatR;


namespace Application.Features.TimeSheets.Handlers.Commands
{
    public class CreateTimeSheetCommandHandler : IRequestHandler<CreateTimeSheetCommand, int>
    {
        private readonly ITimeSheetRepository _timeSheetRepository;

        public CreateTimeSheetCommandHandler(ITimeSheetRepository timeSheetRepository)
        {
            _timeSheetRepository = timeSheetRepository;
        }

        public async Task<int> Handle(CreateTimeSheetCommand request, CancellationToken cancellationToken)
        {
            var timeSheet = new HR.Management.Domain.TimeSheet
            {
                Date = request.Date,
                WorkedHours = request.WorkedHours,
                Notes = request.Notes,
                EmployeeId = request.EmployeeId // Set the employee associated with this timesheet
            };

            await _timeSheetRepository.AddAsync(timeSheet);
            return timeSheet.Id; // Return the ID of the created timesheet record
        }
    }
}
