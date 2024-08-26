using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Application.Features.WorkSchedules.Requests.Queries;
using HR.Management.Application.DTOs;
using MediatR;
using Application.Contracts.Persistance;

namespace Application.Features.WorkSchedules.Handlers.Queries
{
    public class GetAllWorkSchedulesQueryHandler : IRequestHandler<GetAllWorkSchedulesQuery, List<WorkScheduleDto>>
    {
        private readonly IWorkScheduleRepository _workScheduleRepository;
        private readonly IMapper _mapper;

        public GetAllWorkSchedulesQueryHandler(IWorkScheduleRepository workScheduleRepository, IMapper mapper)
        {
            _workScheduleRepository = workScheduleRepository;
            _mapper = mapper;
        }

        public async Task<List<WorkScheduleDto>> Handle(GetAllWorkSchedulesQuery request, CancellationToken cancellationToken)
        {
            var workSchedules = await _workScheduleRepository.GetAllAsync();
            return _mapper.Map<List<WorkScheduleDto>>(workSchedules);
        }
    }
}
