using System;
using Domain.Common;

namespace HR.Management.Domain
{
    public class TimeSheet : BaseDomainEntity
    {
        // public int EmployeeId { get; set; } // Foreign key to Employee
        public DateTime Date { get; set; }
        public TimeSpan WorkedHours { get; set; }
        public string Notes { get; set; } = string.Empty;

        // Navigation property
        
        public Employee? Employee { get; set; }
    }
}
