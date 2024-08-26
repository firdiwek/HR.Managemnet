using Application.Contracts.Persistance;
using Application.Features.WorkScheduleEntries.Commands;
using Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.WorkScheduleEntries.Handlers.Commands
{
    public class UpdateWorkScheduleEntryCommandHandler : IRequestHandler<UpdateWorkScheduleEntryCommand, bool>
    {
        private readonly IWorkScheduleEntryRepository _workScheduleEntryRepository;

        public UpdateWorkScheduleEntryCommandHandler(IWorkScheduleEntryRepository workScheduleEntryRepository)
        {
            _workScheduleEntryRepository = workScheduleEntryRepository;
        }

        public async Task<bool> Handle(UpdateWorkScheduleEntryCommand request, CancellationToken cancellationToken)
        {
            var workScheduleEntry = await _workScheduleEntryRepository.GetByIdAsync(request.Id);
            if (workScheduleEntry == null)
            {
                return false; // WorkScheduleEntry record not found
            }

            workScheduleEntry.WorkScheduleId = request.WorkScheduleId;
            workScheduleEntry.Date = request.Date;
            workScheduleEntry.StartTime = request.StartTime;
            workScheduleEntry.EndTime = request.EndTime;
            workScheduleEntry.ShiftType = request.ShiftType;

            await _workScheduleEntryRepository.UpdateAsync(workScheduleEntry);
            return true;
        }
    }
}
