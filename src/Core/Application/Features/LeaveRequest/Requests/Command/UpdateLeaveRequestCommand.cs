using MediatR;
using System;

namespace Application.Features.LeaveRequests.Commands
{
    public class UpdateLeaveRequestCommand : IRequest<bool>
    {
        public int Id { get; set; } // ID of the leave request to update
        public string LeaveType { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; } = "Pending";
        public string Comments { get; set; } = string.Empty;
    }
}
