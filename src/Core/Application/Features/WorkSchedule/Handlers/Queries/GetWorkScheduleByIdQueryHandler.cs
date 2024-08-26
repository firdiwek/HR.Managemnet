using System.Threading;
using System.Threading.Tasks;
using Application.Features.WorkSchedules.Requests.Queries;
using HR.Management.Application.DTOs;
using MediatR;
using AutoMapper;
using Application.Contracts.Persistance;

namespace Application.Features.WorkSchedules.Handlers.Queries
{
    public class GetWorkScheduleByIdQueryHandler : IRequestHandler<GetWorkScheduleByIdQuery, WorkScheduleDto>
    {
        private readonly IWorkScheduleRepository _workScheduleRepository;
        private readonly IMapper _mapper;

        public GetWorkScheduleByIdQueryHandler(IWorkScheduleRepository workScheduleRepository, IMapper mapper)
        {
            _workScheduleRepository = workScheduleRepository;
            _mapper = mapper;
        }

        public async Task<WorkScheduleDto> Handle(GetWorkScheduleByIdQuery request, CancellationToken cancellationToken)
        {
            var workSchedule = await _workScheduleRepository.GetByIdAsync(request.Id);
            return _mapper.Map<WorkScheduleDto>(workSchedule);
        }
    }
}
