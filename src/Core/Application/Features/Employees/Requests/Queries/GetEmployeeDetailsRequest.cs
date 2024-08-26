using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.Persistance;
using HR.Management.Application.DTOs;
using MediatR;

namespace Application.Features.Employees.Requests.Queries
{
    public class GetEmployeeDetailsRequest : IRequest<EmployeeDto>
    {
        public int Id { get; set; }
    }
}