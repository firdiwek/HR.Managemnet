using Application.Contracts.Persistance;
using Application.Features.WorkSchedules.Commands;
using Domain;
using HR.Management.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.WorkSchedules.Handlers.Commands
{
    public class UpdateWorkScheduleCommandHandler : IRequestHandler<UpdateWorkScheduleCommand, bool>
    {
        private readonly IWorkScheduleRepository _workScheduleRepository;

        public UpdateWorkScheduleCommandHandler(IWorkScheduleRepository workScheduleRepository)
        {
            _workScheduleRepository = workScheduleRepository;
        }

        public async Task<bool> Handle(UpdateWorkScheduleCommand request, CancellationToken cancellationToken)
        {
            var workSchedule = await _workScheduleRepository.GetByIdAsync(request.Id);
            if (workSchedule == null)
            {
                return false; // WorkSchedule record not found
            }

            workSchedule.StartDate = request.StartDate;
            workSchedule.EndDate = request.EndDate;
            workSchedule.ShiftType = request.ShiftType;
            workSchedule.EmployeeId = request.EmployeeId;

            // Optionally update work schedule entries as needed
            // Example: Clear existing entries and add new ones
            workSchedule.WorkScheduleEntries.Clear();
            foreach (var entry in request.WorkScheduleEntries)
            {
                workSchedule.WorkScheduleEntries.Add(new WorkScheduleEntry
                {
                    Date = entry.Date,
                    StartTime = entry.StartTime,
                    EndTime = entry.EndTime,
                    ShiftType = entry.ShiftType
                });
            }

            await _workScheduleRepository.UpdateAsync(workSchedule);
            return true;
        }
    }
}
