using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistance;
using Application.Features.Employees.Requests.Command;
using MediatR;

namespace Application.Features.Employees.Commands
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetByIdAsync(request.Id);
            if (employee == null)
            {
                return false; // Employee not found
            }

             await _employeeRepository.DeleteAsync(request.Id);
            return true;
        }
    }
}
