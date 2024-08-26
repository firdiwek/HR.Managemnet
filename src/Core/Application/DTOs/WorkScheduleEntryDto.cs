using System;
using Application.DTOs.Common;

namespace HR.Management.Application.DTOs
{
    public class WorkScheduleEntryDto: BaseDto
    {
        // public int Id { get; set; }
        public int WorkScheduleId { get; set; } // Foreign key reference to WorkSchedule
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string ShiftType { get; set; } = string.Empty; // E.g., Morning, Evening

        // Optional: If you want to include related entities
        // public WorkScheduleDto WorkSchedule { get; set; }
    }
}
