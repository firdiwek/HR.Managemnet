using Application.Contracts.Persistance;
using Application.Features.LeaveTypes.Commands;
using Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.LeaveTypes.Handlers.Commands
{
    public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, bool>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public UpdateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<bool> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var leaveType = await _leaveTypeRepository.GetByIdAsync(request.Id);
            if (leaveType == null)
            {
                return false; // Leave type not found
            }

            leaveType.Name = request.Name;
            leaveType.Description = request.Description;
            leaveType.MaxDays = request.MaxDays;

            await _leaveTypeRepository.UpdateAsync(leaveType);
            return true;
        }
    }
}
