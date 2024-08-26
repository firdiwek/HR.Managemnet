using System;
using Application.DTOs.Common;

namespace HR.Management.Application.DTOs
{
    public class TimeSheetDto: BaseDto
    {
        // public int Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan WorkedHours { get; set; }
        public string Notes { get; set; } = string.Empty;

        // Optional: If you want to include related entities
        public int EmployeeId { get; set; } // Foreign key reference to Employee
    }
}
