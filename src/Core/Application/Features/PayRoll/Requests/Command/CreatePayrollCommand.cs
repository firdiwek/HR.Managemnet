using MediatR;
using System;

namespace Application.Features.Payrolls.Commands
{
    public class CreatePayrollCommand : IRequest<int>
    {
        public decimal BasicSalary { get; set; }
        public decimal Allowances { get; set; }
        public decimal Deductions { get; set; }
        public DateTime PayDate { get; set; }
        public int EmployeeId { get; set; } // ID of the employee associated with this payroll
    }
}
