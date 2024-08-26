using MediatR;
using System;

namespace Application.Features.Payrolls.Commands
{
    public class UpdatePayrollCommand : IRequest<bool>
    {
        public int Id { get; set; } // ID of the payroll record to update
        public decimal BasicSalary { get; set; }
        public decimal Allowances { get; set; }
        public decimal Deductions { get; set; }
        public DateTime PayDate { get; set; }
        public int EmployeeId { get; set; } // ID of the employee associated with this payroll
    }
}
