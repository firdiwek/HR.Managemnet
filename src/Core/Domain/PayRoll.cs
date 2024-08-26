using System;
using System.Collections.Generic;
using Domain.Common;

namespace HR.Management.Domain
{
    public class Payroll : BaseDomainEntity
    {
        // public int EmployeeId { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal Allowances { get; set; }
        public decimal Deductions { get; set; }
        public decimal NetSalary => BasicSalary + Allowances - Deductions;
        public DateTime PayDate { get; set; }

        // Navigation property
        
        public Employee?  Employee { get; set; }
        public ICollection<WorkSchedule> WorkSchedules { get; set; } = new List<WorkSchedule>();
        public ICollection<TimeSheet> Timesheets { get; set; } = new List<TimeSheet>();
    }
}
