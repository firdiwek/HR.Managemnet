using Application.Contracts.Persistance;
using Application.Features.Payrolls.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Payrolls.Handlers.Commands
{
    public class DeletePayrollCommandHandler : IRequestHandler<DeletePayrollCommand, bool>
    {
        private readonly IPayRollRepository _payrollRepository;

        public DeletePayrollCommandHandler(IPayRollRepository payrollRepository)
        {
            _payrollRepository = payrollRepository;
        }

        public async Task<bool> Handle(DeletePayrollCommand request, CancellationToken cancellationToken)
        {
            var payroll = await _payrollRepository.GetByIdAsync(request.Id);
            if (payroll == null)
            {
                return false; // Payroll record not found
            }

            await _payrollRepository.DeleteAsync(request.Id);
            return true;
        }
    }
}
