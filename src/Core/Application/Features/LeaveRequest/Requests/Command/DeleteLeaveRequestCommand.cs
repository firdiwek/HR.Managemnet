using MediatR;

namespace Application.Features.LeaveRequests.Commands
{
    public class DeleteLeaveRequestCommand : IRequest<bool>
    {
        public int Id { get; set; } // ID of the leave request to delete
    }
}
