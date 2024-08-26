using System;
using Application.DTOs.Common;

namespace HR.Management.Application.DTOs
{
    public class LeaveRequestDto: BaseDto
    {
        // public int Id { get; set; }
        public string LeaveType { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NumberOfDays => (EndDate - StartDate).Days + 1; // Calculated property
        public string Status { get; set; } = "Pending";
        public string Comments { get; set; } = string.Empty;
        public int EmployeeId { get; set; } // Optional: Employee ID if needed
    }
}
