using MediatR;
using HR.Management.Application.DTOs;

namespace Application.Features.TimeSheets.Requests.Queries
{
    public class GetTimeSheetByIdQuery : IRequest<TimeSheetDto>
    {
        public int Id { get; set; }

    }
}
