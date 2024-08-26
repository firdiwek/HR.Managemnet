using Application.Contracts.Persistance;
using Application.Features.LeaveRequests.Commands;
using Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.LeaveRequests.Handlers.Commands
{
    public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, bool>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        public UpdateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
        }

        public async Task<bool> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestRepository.GetByIdAsync(request.Id);
            if (leaveRequest == null)
            {
                return false; // Leave request not found
            }

            leaveRequest.LeaveType = request.LeaveType;
            leaveRequest.StartDate = request.StartDate;
            leaveRequest.EndDate = request.EndDate;
            leaveRequest.Status = request.Status;
            leaveRequest.Comments = request.Comments;

            await _leaveRequestRepository.UpdateAsync(leaveRequest);
            return true;
        }
    }
}
