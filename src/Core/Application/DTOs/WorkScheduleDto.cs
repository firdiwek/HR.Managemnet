using System;
using System.Collections.Generic;
using Application.DTOs;
using Application.DTOs.Common;

namespace HR.Management.Application.DTOs
{
    public class WorkScheduleDto: BaseDto
    {
        // public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ShiftType { get; set; } = string.Empty;
        
        // Optional: If you want to include related entities
        public int EmployeeId { get; set; } // Foreign key reference to Employee
        
        public ICollection<WorkScheduleEntryDto> WorkScheduleEntries { get; set; } = new List<WorkScheduleEntryDto>();
    }
}
