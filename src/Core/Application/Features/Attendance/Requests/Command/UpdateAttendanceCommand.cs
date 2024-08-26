using MediatR;
using System;

namespace Application.Features.Attendance.Commands
{
    public class UpdateAttendanceCommand : IRequest<bool>
    {
        public int Id { get; set; } // ID of the attendance record to update
        public DateTime Date { get; set; }
        public TimeSpan ClockInTime { get; set; }
        public TimeSpan ClockOutTime { get; set; }
        public TimeSpan? BreakStartTime { get; set; }
        public TimeSpan? BreakEndTime { get; set; }
        public string Status { get; set; } = "Present";
    }
}
