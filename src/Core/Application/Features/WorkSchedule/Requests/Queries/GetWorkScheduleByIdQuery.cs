using MediatR;
using HR.Management.Application.DTOs;

namespace Application.Features.WorkSchedules.Requests.Queries
{
    public class GetWorkScheduleByIdQuery : IRequest<WorkScheduleDto>
    {
        public int Id { get; set; }

        public GetWorkScheduleByIdQuery(int id)
        {
            Id = id;
        }
    }
}
