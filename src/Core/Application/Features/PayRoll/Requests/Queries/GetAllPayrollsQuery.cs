using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.Management.Application.DTOs;
using MediatR;

namespace Application.Features.PayRoll.Requests.Queries
{
    public class GetAllPayrollsQuery:IRequest< List< PayrollDto>>
    {
        
    }
}