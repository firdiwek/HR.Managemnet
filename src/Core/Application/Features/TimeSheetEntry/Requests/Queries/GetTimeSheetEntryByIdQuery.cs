using MediatR;
using HR.Management.Application.DTOs;

namespace Application.Features.TimeSheetEntries.Requests.Queries
{
    public class GetTimeSheetEntryByIdQuery : IRequest<TimeSheetEntryDto>
    {
        public int Id { get; set; }

        public GetTimeSheetEntryByIdQuery(int id)
        {
            Id = id;
        }
    }
}
