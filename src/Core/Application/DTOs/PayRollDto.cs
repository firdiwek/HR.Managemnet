using System;
using System.Collections.Generic;
using Application.DTOs.Common;

namespace HR.Management.Application.DTOs
{
    public class PayrollDto: BaseDto
    {
        // public int Id { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal Allowances { get; set; }
        public decimal Deductions { get; set; }
        public decimal NetSalary => BasicSalary + Allowances - Deductions; // Calculated property
        public DateTime PayDate { get; set; }
        public int EmployeeId { get; set; } // Optional: Employee ID if needed

        // Optional: If you want to include related entities
        public IEnumerable<int> WorkScheduleIds { get; set; } = new List<int>();
        public IEnumerable<int> TimeSheetIds { get; set; } = new List<int>();
    }
}
