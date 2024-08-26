using Application.Contracts.Persistance;
using Application.Features.LeaveTypes.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.LeaveTypes.Handlers.Commands
{
    public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, bool>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<bool> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var leaveType = await _leaveTypeRepository.GetByIdAsync(request.Id);
            if (leaveType == null)
            {
                return false; // Leave type not found
            }

            await _leaveTypeRepository.DeleteAsync(request.Id);
            return true;
        }
    }
}
