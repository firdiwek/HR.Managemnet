using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.Persistance;
using Application.Features.Employees.Requests;
using Application.Features.Employees.Requests.Queries;
using AutoMapper;
using HR.Management.Application.DTOs;
using MediatR;

namespace Application.Features.Employees.Handlers.Queries
{
    public class GetEmployeeRequestHandler : IRequestHandler<GetEmployeeRequest, List<EmployeeDto>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public GetEmployeeRequestHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        public async Task<List<EmployeeDto>> Handle(GetEmployeeRequest request, CancellationToken cancellationToken)
        {
           var Employees = await _employeeRepository.GetAllAsync();
           return _mapper.Map<List<EmployeeDto>>(Employees);
        }
    }
}