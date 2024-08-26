using Application.Contracts.Persistance;
using Application.Features.WorkSchedules.Commands;
using Domain;
using HR.Management.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.WorkSchedules.Handlers.Commands
{
    public class CreateWorkScheduleCommandHandler : IRequestHandler<CreateWorkScheduleCommand, int>
    {
        private readonly IWorkScheduleRepository _workScheduleRepository;

        public CreateWorkScheduleCommandHandler(IWorkScheduleRepository workScheduleRepository)
        {
            _workScheduleRepository = workScheduleRepository;
        }

        public async Task<int> Handle(CreateWorkScheduleCommand request, CancellationToken cancellationToken)
        {
            var workSchedule = new WorkSchedule
            {
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                ShiftType = request.ShiftType,
                EmployeeId = request.EmployeeId
            };

            // Optionally, you could also handle work schedule entries here, but make sure to update this
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

            await _workScheduleRepository.AddAsync(workSchedule);
            return workSchedule.Id; // Return the ID of the created work schedule record
        }
    }
}
