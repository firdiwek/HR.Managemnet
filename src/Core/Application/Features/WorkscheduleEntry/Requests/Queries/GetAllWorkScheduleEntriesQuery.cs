using System.Collections.Generic;
using MediatR;
using HR.Management.Application.DTOs;

namespace Application.Features.WorkScheduleEntries.Requests.Queries
{
    public class GetAllWorkScheduleEntriesQuery : IRequest<List<WorkScheduleEntryDto>>
    {
    }
}
