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
    public class GetEmployeeDetailsHandler : IRequestHandler<GetEmployeeDetailsRequest, EmployeeDto>
    {
         private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public GetEmployeeDetailsHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        public async Task<EmployeeDto> Handle(GetEmployeeDetailsRequest request, CancellationToken cancellationToken)
        {
            var Employee= await _employeeRepository.GetByIdAsync(request.Id);
            return _mapper.Map<EmployeeDto>(Employee);
        }
    }



}