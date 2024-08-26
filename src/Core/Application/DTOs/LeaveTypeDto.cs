using System.Collections.Generic;
using Application.DTOs.Common;

namespace HR.Management.Application.DTOs
{
    public class LeaveTypeDto: BaseDto
    {
        // public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // E.g., Annual Leave, Sick Leave, etc.
        public string Description { get; set; } = string.Empty;
        public int MaxDays { get; set; } // Maximum number of days allowed for this leave type
        public IEnumerable<int> LeaveRequestIds { get; set; } = new List<int>(); // Optional: IDs of associated leave requests
    }
}
