using MediatR;
using HR.Management.Application.DTOs;

namespace Application.Features.WorkScheduleEntries.Requests.Queries
{
    public class GetWorkScheduleEntryByIdQuery : IRequest<WorkScheduleEntryDto>
    {
        public int Id { get; set; }

        public GetWorkScheduleEntryByIdQuery(int id)
        {
            Id = id;
        }
    }
}
