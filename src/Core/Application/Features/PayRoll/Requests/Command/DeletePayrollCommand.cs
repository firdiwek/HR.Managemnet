using MediatR;

namespace Application.Features.Payrolls.Commands
{
    public class DeletePayrollCommand : IRequest<bool>
    {
        public int Id { get; set; } // ID of the payroll record to delete
    }
}
