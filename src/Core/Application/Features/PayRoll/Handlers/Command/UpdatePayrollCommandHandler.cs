using Application.Contracts.Persistance;
using Application.Features.Payrolls.Commands;
using Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Payrolls.Handlers.Commands
{
    public class UpdatePayrollCommandHandler : IRequestHandler<UpdatePayrollCommand, bool>
    {
        private readonly IPayRollRepository _payrollRepository;

        public UpdatePayrollCommandHandler(IPayRollRepository payrollRepository)
        {
            _payrollRepository = payrollRepository;
        }

        public async Task<bool> Handle(UpdatePayrollCommand request, CancellationToken cancellationToken)
        {
            var payroll = await _payrollRepository.GetByIdAsync(request.Id);
            if (payroll == null)
            {
                return false; // Payroll record not found
            }

            payroll.BasicSalary = request.BasicSalary;
            payroll.Allowances = request.Allowances;
            payroll.Deductions = request.Deductions;
            payroll.PayDate = request.PayDate;
            payroll.EmployeeId = request.EmployeeId;

            await _payrollRepository.UpdateAsync(payroll);
            return true;
        }
    }
}
