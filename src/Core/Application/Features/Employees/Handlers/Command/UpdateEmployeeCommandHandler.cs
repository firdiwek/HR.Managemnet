using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.Persistance;
using Application.Features.Employees.Requests.Command;
using MediatR;

namespace Application.Features.Employees.Handlers.Command
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand,bool>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<bool> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetByIdAsync(request.Id);
            if (employee == null)
            {
                return false;
            }
            employee.FirstName = request.FirstName;
            employee.LastName = request.LastName;
            employee.DateOfBirth = request.DateOfBirth;
            employee.Gender = request.Gender;
            employee.EmailAddress = request.EmailAddress;
            employee.PhoneNumber = request.PhoneNumber;
            employee.Address = request.Address;
            employee.DepartmentId = request.DepartmentId;
            employee.JobTitle = request.JobTitle;
            employee.ManagerId = request.ManagerId;
            employee.HireDate = request.HireDate;
            employee.EmploymentStatus = request.EmploymentStatus;
            employee.ContractType = request.ContractType;
            employee.Salary = request.Salary;
            await _employeeRepository.UpdateAsync(employee);
            return true;
        }
    }
}