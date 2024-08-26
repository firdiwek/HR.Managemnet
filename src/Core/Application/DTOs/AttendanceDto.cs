using System;
using Application.DTOs.Common;

namespace HR.Management.Application.DTOs
{
    public class AttendanceDto : BaseDto
    {
        // public int Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan ClockInTime { get; set; }
        public TimeSpan ClockOutTime { get; set; }
        public TimeSpan? BreakStartTime { get; set; }
        public TimeSpan? BreakEndTime { get; set; }
        public string Status { get; set; } = "Present";
        public int EmployeeId { get; set; } // Optional: If you want to expose the employee ID
    }
}
