using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.Persistance;
using Application.Features.Employees.Requests.Command;
using AutoMapper;
using HR.Management.Domain;
using MediatR;

namespace Application.Features.Employees.Handlers.Command
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, int>
    {
        private readonly IEmployeeRepository _employeeRepository;


        public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<int> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = new Employee
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth,
                Gender = request.Gender,
                EmailAddress = request.EmailAddress,
                PhoneNumber = request.PhoneNumber,
                Address = request.Address,
                DepartmentId = request.DepartmentId,
                JobTitle = request.JobTitle,
                ManagerId = request.ManagerId,
                HireDate = request.HireDate,
                EmploymentStatus = request.EmploymentStatus,
                ContractType = request.ContractType,
                Salary = request.Salary
        
            };
            await _employeeRepository.AddAsync(employee);
            return employee.Id;
        }
    }
}