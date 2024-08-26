using MediatR;

namespace Application.Features.LeaveTypes.Commands
{
    public class DeleteLeaveTypeCommand : IRequest<bool>
    {
        public int Id { get; set; } // ID of the leave type to delete
    }
}
