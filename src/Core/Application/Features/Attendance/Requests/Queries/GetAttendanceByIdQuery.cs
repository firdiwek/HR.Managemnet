using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.Management.Application.DTOs;
using MediatR;

namespace Application.Features.Attendance.Handlers.Queries
{
    public class GetAttendanceByIdQuery : IRequest<AttendanceDto>
    {
        public int Id { get; set; }
        
    }
}