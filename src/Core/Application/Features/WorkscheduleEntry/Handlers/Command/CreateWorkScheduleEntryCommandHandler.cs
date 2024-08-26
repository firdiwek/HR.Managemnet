using Application.Contracts.Persistance;
using Application.Features.WorkScheduleEntries.Commands;
using Domain;
using HR.Management.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.WorkScheduleEntries.Handlers.Commands
{
    public class CreateWorkScheduleEntryCommandHandler : IRequestHandler<CreateWorkScheduleEntryCommand, int>
    {
        private readonly IWorkScheduleEntryRepository _workScheduleEntryRepository;

        public CreateWorkScheduleEntryCommandHandler(IWorkScheduleEntryRepository workScheduleEntryRepository)
        {
            _workScheduleEntryRepository = workScheduleEntryRepository;
        }

        public async Task<int> Handle(CreateWorkScheduleEntryCommand request, CancellationToken cancellationToken)
        {
            var workScheduleEntry = new WorkScheduleEntry
            {
                WorkScheduleId = request.WorkScheduleId,
                Date = request.Date,
                StartTime = request.StartTime,
                EndTime = request.EndTime,
                ShiftType = request.ShiftType
            };

            await _workScheduleEntryRepository.AddAsync(workScheduleEntry);
            return workScheduleEntry.Id; // Return the ID of the created work schedule entry record
        }
    }
}
