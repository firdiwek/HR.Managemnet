using System;
using System.Collections.Generic;
using Domain.Common;

namespace HR.Management.Domain
{
    public class WorkSchedule : BaseDomainEntity
    {
        // public int EmployeeId { get; set; } // Foreign key to Employee
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ShiftType { get; set; } = string.Empty; // E.g., Morning, Evening, Night

        // Navigation property
        
        public Employee? Employee { get; set; }
        public ICollection<WorkScheduleEntry> WorkScheduleEntries { get; set; } = new List<WorkScheduleEntry>();
    }
}
