using Application.Contracts.Persistance;
using Application.Features.WorkScheduleEntries.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.WorkScheduleEntries.Handlers.Commands
{
    public class DeleteWorkScheduleEntryCommandHandler : IRequestHandler<DeleteWorkScheduleEntryCommand, bool>
    {
        private readonly IWorkScheduleEntryRepository _workScheduleEntryRepository;

        public DeleteWorkScheduleEntryCommandHandler(IWorkScheduleEntryRepository workScheduleEntryRepository)
        {
            _workScheduleEntryRepository = workScheduleEntryRepository;
        }

        public async Task<bool> Handle(DeleteWorkScheduleEntryCommand request, CancellationToken cancellationToken)
        {
            var workScheduleEntry = await _workScheduleEntryRepository.GetByIdAsync(request.Id);
            if (workScheduleEntry == null)
            {
                return false; // WorkScheduleEntry record not found
            }

            await _workScheduleEntryRepository.DeleteAsync(request.Id);
            return true;
        }
    }
}
