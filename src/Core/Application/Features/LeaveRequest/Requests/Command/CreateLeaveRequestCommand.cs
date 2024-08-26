using MediatR;
using System;

namespace Application.Features.LeaveRequests.Commands
{
    public class CreateLeaveRequestCommand : IRequest<int>
    {
        public string LeaveType { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Comments { get; set; } = string.Empty;
        public int EmployeeId { get; set; } // Employee associated with the leave request
    }
}
