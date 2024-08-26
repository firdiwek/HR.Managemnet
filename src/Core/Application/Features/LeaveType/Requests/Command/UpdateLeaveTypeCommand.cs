using MediatR;

namespace Application.Features.LeaveTypes.Commands
{
    public class UpdateLeaveTypeCommand : IRequest<bool>
    {
        public int Id { get; set; } // ID of the leave type to update
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int MaxDays { get; set; }
    }
}
