using System;
using Domain.Common;

namespace HR.Management.Domain
{
    public class Attendance : BaseDomainEntity
    {
        public DateTime Date { get; set; }
        public TimeSpan ClockInTime { get; set; }
        public TimeSpan ClockOutTime { get; set; }
        public TimeSpan? BreakStartTime { get; set; }
        public TimeSpan? BreakEndTime { get; set; }
        public string Status { get; set; } = "Present"; // Possible values: Present, Absent, Late, etc.

        // Navigation property
        required
        public Employee Employee { get; set; }
    }
}
