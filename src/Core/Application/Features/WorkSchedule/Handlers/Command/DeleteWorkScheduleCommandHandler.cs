using Application.Contracts.Persistance;
using Application.Features.WorkSchedules.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.WorkSchedules.Handlers.Commands
{
    public class DeleteWorkScheduleCommandHandler : IRequestHandler<DeleteWorkScheduleCommand, bool>
    {
        private readonly IWorkScheduleRepository _workScheduleRepository;

        public DeleteWorkScheduleCommandHandler(IWorkScheduleRepository workScheduleRepository)
        {
            _workScheduleRepository = workScheduleRepository;
        }

        public async Task<bool> Handle(DeleteWorkScheduleCommand request, CancellationToken cancellationToken)
        {
            var workSchedule = await _workScheduleRepository.GetByIdAsync(request.Id);
            if (workSchedule == null)
            {
                return false; // WorkSchedule record not found
            }

            await _workScheduleRepository.DeleteAsync(request.Id);
            return true;
        }
    }
}
