using System;
using Domain.Common;

namespace HR.Management.Domain
{
    public class WorkScheduleEntry : BaseDomainEntity
    {
        public int WorkScheduleId { get; set; } // Foreign key to WorkSchedule
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string ShiftType { get; set; } = string.Empty; // E.g., Morning, Evening

        // Navigation property
        public WorkSchedule? WorkSchedule { get; set; }
    }
}
