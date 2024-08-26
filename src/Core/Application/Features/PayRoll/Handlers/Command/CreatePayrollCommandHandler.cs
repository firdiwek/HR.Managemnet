using Application.Contracts.Persistance;
using Application.Features.Payrolls.Commands;
using Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Payrolls.Handlers.Commands
{
    public class CreatePayrollCommandHandler : IRequestHandler<CreatePayrollCommand, int>
    {
        private readonly IPayRollRepository _payrollRepository;

        public CreatePayrollCommandHandler(IPayRollRepository payrollRepository)
        {
            _payrollRepository = payrollRepository;
        }

        public async Task<int> Handle(CreatePayrollCommand request, CancellationToken cancellationToken)
        {
            var payroll = new HR.Management.Domain.Payroll
            {
                BasicSalary = request.BasicSalary,
                Allowances = request.Allowances,
                Deductions = request.Deductions,
                PayDate = request.PayDate,
                EmployeeId = request.EmployeeId // Set the employee associated with this payroll record
            };

            await _payrollRepository.AddAsync(payroll);
            return payroll.Id;
        }
    }
}
