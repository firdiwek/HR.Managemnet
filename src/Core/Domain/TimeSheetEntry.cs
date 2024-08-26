using System;
using Domain.Common;

namespace HR.Management.Domain
{
    public class TimeSheetEntry : BaseDomainEntity
    {
        // public int EmployeeId { get; set; } // Foreign key to Employee
        public Employee? Employee { get; set; } // Navigation property

        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public TimeSpan TotalHours { get; set; }
        public string Description { get; set; } = string.Empty; // Description of the task or project

        
    }
}
