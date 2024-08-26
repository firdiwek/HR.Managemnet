using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.Management.Application.DTOs;
using MediatR;

namespace Application.Features.LeaveRequest.Requests.Queries
{
    public class GetLeaveRequestByIdQuery : IRequest<LeaveRequestDto>
    {
        public int Id { get; set; }
    }
}