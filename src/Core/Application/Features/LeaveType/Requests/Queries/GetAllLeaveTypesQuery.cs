using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.Management.Application.DTOs;
using MediatR;

namespace Application.Features.LeaveType.Requests.Queries
{
    public class GetAllLeaveTypesQuery : IRequest<List<LeaveTypeDto>>
    {
        
    }
}