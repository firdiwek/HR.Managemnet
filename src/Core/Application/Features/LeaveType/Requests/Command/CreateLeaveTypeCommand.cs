using MediatR;

namespace Application.Features.LeaveTypes.Commands
{
    public class CreateLeaveTypeCommand : IRequest<int>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int MaxDays { get; set; }
    }
}
