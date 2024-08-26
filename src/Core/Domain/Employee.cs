using System;
using System.Collections.Generic;
using Domain.Common;

namespace HR.Management.Domain
{
    public class Employee : BaseDomainEntity
    {
        // Employee Core Informations/Attributes
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        public int DepartmentId { get; set; }
        public Department? Department { get; set; }

        // Employment Details
        public string JobTitle { get; set; } = string.Empty;
        public int? ManagerId { get; set; } // Reference to the employee's direct manager (nullable if no manager)
        public DateTime HireDate { get; set; }
        public string EmploymentStatus { get; set; } = string.Empty; // Active/Inactive
        public string ContractType { get; set; } = string.Empty;
        public decimal Salary { get; set; }

       
         // Navigation properties
         
        public ICollection<Payroll> Payrolls { get; set; } = new List<Payroll>();
        public ICollection<WorkSchedule> WorkSchedules { get; set; } = new List<WorkSchedule>();
        public ICollection<TimeSheet> Timesheets { get; set; } = new List<TimeSheet>();
        public ICollection<LeaveRequest> LeaveRequests { get; set; } = new List<LeaveRequest>();
        public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
        public ICollection<TimeSheetEntry> TimeSheetEntries { get; set; } = new List<TimeSheetEntry>();

    

    }
}
