using Application.Contracts.Persistance;
using Application.Features.TimeSheetEntries.Commands;
using Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.TimeSheetEntries.Handlers.Commands
{
    public class CreateTimeSheetEntryCommandHandler : IRequestHandler<CreateTimeSheetEntryCommand, int>
    {
        private readonly ITimeSheetEntryRepository _timeSheetEntryRepository;

        public CreateTimeSheetEntryCommandHandler(ITimeSheetEntryRepository timeSheetEntryRepository)
        {
            _timeSheetEntryRepository = timeSheetEntryRepository;
        }

        public async Task<int> Handle(CreateTimeSheetEntryCommand request, CancellationToken cancellationToken)
        {
            var timeSheetEntry = new HR.Management.Domain.TimeSheetEntry
            {
                Date = request.Date,
                StartTime = request.StartTime,
                EndTime = request.EndTime,
                TotalHours = request.TotalHours,
                Description = request.Description,
                EmployeeId = request.EmployeeId // Set the employee associated with this time sheet entry
            };

            await _timeSheetEntryRepository.AddAsync(timeSheetEntry);
            return timeSheetEntry.Id; // Return the ID of the created time sheet entry record
        }
    }
}
