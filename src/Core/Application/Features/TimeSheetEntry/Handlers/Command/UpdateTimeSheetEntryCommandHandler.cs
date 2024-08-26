using Application.Contracts.Persistance;
using Application.Features.TimeSheetEntries.Commands;
using Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.TimeSheetEntries.Handlers.Commands
{
    public class UpdateTimeSheetEntryCommandHandler : IRequestHandler<UpdateTimeSheetEntryCommand, bool>
    {
        private readonly ITimeSheetEntryRepository _timeSheetEntryRepository;

        public UpdateTimeSheetEntryCommandHandler(ITimeSheetEntryRepository timeSheetEntryRepository)
        {
            _timeSheetEntryRepository = timeSheetEntryRepository;
        }

        public async Task<bool> Handle(UpdateTimeSheetEntryCommand request, CancellationToken cancellationToken)
        {
            var timeSheetEntry = await _timeSheetEntryRepository.GetByIdAsync(request.Id);
            if (timeSheetEntry == null)
            {
                return false; // TimeSheetEntry record not found
            }

            timeSheetEntry.Date = request.Date;
            timeSheetEntry.StartTime = request.StartTime;
            timeSheetEntry.EndTime = request.EndTime;
            timeSheetEntry.TotalHours = request.TotalHours;
            timeSheetEntry.Description = request.Description;
            timeSheetEntry.EmployeeId = request.EmployeeId;

            await _timeSheetEntryRepository.UpdateAsync(timeSheetEntry);
            return true;
        }
    }
}
