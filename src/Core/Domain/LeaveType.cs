using System.Collections.Generic;
using Domain.Common;

namespace HR.Management.Domain
{
    public class LeaveType : BaseDomainEntity
    {
        public string Name { get; set; } = string.Empty; // E.g., Annual Leave, Sick Leave, etc.
        public string Description { get; set; } = string.Empty;
        public int MaxDays { get; set; } // Maximum number of days allowed for this leave type

        // Navigation property
        public ICollection<LeaveRequest> LeaveRequests { get; set; } = new List<LeaveRequest>();
    }
}
