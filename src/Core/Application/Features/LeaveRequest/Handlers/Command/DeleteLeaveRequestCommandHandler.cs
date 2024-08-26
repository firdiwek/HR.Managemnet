using Application.Contracts.Persistance;
using Application.Features.LeaveRequests.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.LeaveRequests.Handlers.Commands
{
    public class DeleteLeaveRequestCommandHandler : IRequestHandler<DeleteLeaveRequestCommand, bool>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        public DeleteLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
        }

        public async Task<bool> Handle(DeleteLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestRepository.GetByIdAsync(request.Id);
            if (leaveRequest == null)
            {
                return false; // Leave request not found
            }

            await _leaveRequestRepository.DeleteAsync(request.Id);
            return true;
        }
    }
}
