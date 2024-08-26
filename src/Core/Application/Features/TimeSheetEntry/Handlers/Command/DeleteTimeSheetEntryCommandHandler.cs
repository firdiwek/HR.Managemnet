using Application.Contracts.Persistance;
using Application.Features.TimeSheetEntries.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.TimeSheetEntries.Handlers.Commands
{
    public class DeleteTimeSheetEntryCommandHandler : IRequestHandler<DeleteTimeSheetEntryCommand, bool>
    {
        private readonly ITimeSheetEntryRepository _timeSheetEntryRepository;

        public DeleteTimeSheetEntryCommandHandler(ITimeSheetEntryRepository timeSheetEntryRepository)
        {
            _timeSheetEntryRepository = timeSheetEntryRepository;
        }

        public async Task<bool> Handle(DeleteTimeSheetEntryCommand request, CancellationToken cancellationToken)
        {
            var timeSheetEntry = await _timeSheetEntryRepository.GetByIdAsync(request.Id);
            if (timeSheetEntry == null)
            {
                return false; // TimeSheetEntry record not found
            }

            await _timeSheetEntryRepository.DeleteAsync(request.Id);
            return true;
        }
    }
}
