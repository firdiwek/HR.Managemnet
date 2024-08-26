using System.Collections.Generic;
using MediatR;
using HR.Management.Application.DTOs;

namespace Application.Features.TimeSheetEntries.Requests.Queries
{
    public class GetAllTimeSheetEntriesQuery : IRequest<List<TimeSheetEntryDto>>
    {
    }
}
