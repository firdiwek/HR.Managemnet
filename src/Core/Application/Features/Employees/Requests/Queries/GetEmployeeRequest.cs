using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.Management.Application.DTOs;
using MediatR;

namespace Application.Features.Employees.Requests.Queries
{
    public class GetEmployeeRequest : IRequest<List<EmployeeDto>>
    {
        
    }
} 