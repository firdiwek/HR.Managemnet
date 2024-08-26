using Application.Contracts.Persistance;
using Application.Features.TimeSheets.Commands;
using Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.TimeSheets.Handlers.Commands
{
    public class UpdateTimeSheetCommandHandler : IRequestHandler<UpdateTimeSheetCommand, bool>
    {
        private readonly ITimeSheetRepository _timeSheetRepository;

        public UpdateTimeSheetCommandHandler(ITimeSheetRepository timeSheetRepository)
        {
            _timeSheetRepository = timeSheetRepository;
        }

        public async Task<bool> Handle(UpdateTimeSheetCommand request, CancellationToken cancellationToken)
        {
            var timeSheet = await _timeSheetRepository.GetByIdAsync(request.Id);
            if (timeSheet == null)
            {
                return false; // TimeSheet record not found
            }

            timeSheet.Date = request.Date;
            timeSheet.WorkedHours = request.WorkedHours;
            timeSheet.Notes = request.Notes;
            timeSheet.EmployeeId = request.EmployeeId;

            await _timeSheetRepository.UpdateAsync(timeSheet);
            return true;
        }
    }
}
