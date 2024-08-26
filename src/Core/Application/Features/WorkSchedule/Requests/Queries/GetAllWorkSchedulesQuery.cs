using System.Collections.Generic;
using MediatR;
using HR.Management.Application.DTOs;

namespace Application.Features.WorkSchedules.Requests.Queries
{
    public class GetAllWorkSchedulesQuery : IRequest<List<WorkScheduleDto>>
    {
    }
}
