using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Application.Features.WorkScheduleEntries.Requests.Queries;
using HR.Management.Application.DTOs;
using MediatR;
using Application.Contracts.Persistance;

namespace Application.Features.WorkScheduleEntries.Handlers.Queries
{
    public class GetAllWorkScheduleEntriesQueryHandler : IRequestHandler<GetAllWorkScheduleEntriesQuery, List<WorkScheduleEntryDto>>
    {
        private readonly IWorkScheduleEntryRepository _workScheduleEntryRepository;
        private readonly IMapper _mapper;

        public GetAllWorkScheduleEntriesQueryHandler(IWorkScheduleEntryRepository workScheduleEntryRepository, IMapper mapper)
        {
            _workScheduleEntryRepository = workScheduleEntryRepository;
            _mapper = mapper;
        }

        public async Task<List<WorkScheduleEntryDto>> Handle(GetAllWorkScheduleEntriesQuery request, CancellationToken cancellationToken)
        {
            var workScheduleEntries = await _workScheduleEntryRepository.GetAllAsync();
            return _mapper.Map<List<WorkScheduleEntryDto>>(workScheduleEntries);
        }
    }
}
