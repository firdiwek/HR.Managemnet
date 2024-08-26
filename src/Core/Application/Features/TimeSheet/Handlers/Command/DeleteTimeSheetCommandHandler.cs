using Application.Contracts.Persistance;
using Application.Features.TimeSheets.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.TimeSheets.Handlers.Commands
{
    public class DeleteTimeSheetCommandHandler : IRequestHandler<DeleteTimeSheetCommand, bool>
    {
        private readonly ITimeSheetRepository _timeSheetRepository;

        public DeleteTimeSheetCommandHandler(ITimeSheetRepository timeSheetRepository)
        {
            _timeSheetRepository = timeSheetRepository;
        }

        public async Task<bool> Handle(DeleteTimeSheetCommand request, CancellationToken cancellationToken)
        {
            var timeSheet = await _timeSheetRepository.GetByIdAsync(request.Id);
            if (timeSheet == null)
            {
                return false; // TimeSheet record not found
            }

            await _timeSheetRepository.DeleteAsync(request.Id);
            return true;
        }
    }
}
