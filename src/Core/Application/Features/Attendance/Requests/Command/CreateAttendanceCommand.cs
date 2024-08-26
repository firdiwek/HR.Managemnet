using MediatR;
using System;

namespace Application.Features.Attendance.Commands
{
    public class CreateAttendanceCommand : IRequest<int>
    {
        public DateTime Date { get; set; }
        public TimeSpan ClockInTime { get; set; }
        public TimeSpan ClockOutTime { get; set; }
        public TimeSpan? BreakStartTime { get; set; }
        public TimeSpan? BreakEndTime { get; set; }
        public string Status { get; set; } = "Present";
        public int EmployeeId { get; set; } // Employee associated with this attendance record
    }
}
