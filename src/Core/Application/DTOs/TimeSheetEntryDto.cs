using System;
using Application.DTOs.Common;

namespace HR.Management.Application.DTOs
{
    public class TimeSheetEntryDto: BaseDto
    {
        // public int Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public TimeSpan TotalHours { get; set; }
        public string Description { get; set; } = string.Empty;
        
        // Optional: If you want to include related entities
        public int EmployeeId { get; set; } // Foreign key reference to Employee
    }
}
