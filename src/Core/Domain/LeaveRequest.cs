using System;
using Domain.Common;

namespace HR.Management.Domain
{
    public class LeaveRequest : BaseDomainEntity
    {
        // public int EmployeeId { get; set; } // Foreign key to Employee
        public string LeaveType { get; set; } = string.Empty; // E.g., Sick Leave, Vacation, etc.
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NumberOfDays => (EndDate - StartDate).Days + 1; // Calculating number of leave days
        public string Status { get; set; } = "Pending"; // E.g., Pending, Approved, Rejected
        public string Comments { get; set; } = string.Empty;

        // Navigation property
        required
        public Employee Employee { get; set; }
    }
}
