using System.Threading;
using System.Threading.Tasks;
using Application.Features.WorkScheduleEntries.Requests.Queries;
using HR.Management.Application.DTOs;
using MediatR;
using AutoMapper;
using Application.Contracts.Persistance;

namespace Application.Features.WorkScheduleEntries.Handlers.Queries
{
    public class GetWorkScheduleEntryByIdQueryHandler : IRequestHandler<GetWorkScheduleEntryByIdQuery, WorkScheduleEntryDto>
    {
        private readonly IWorkScheduleEntryRepository _workScheduleEntryRepository;
        private readonly IMapper _mapper;

        public GetWorkScheduleEntryByIdQueryHandler(IWorkScheduleEntryRepository workScheduleEntryRepository, IMapper mapper)
        {
            _workScheduleEntryRepository = workScheduleEntryRepository;
            _mapper = mapper;
        }

        public async Task<WorkScheduleEntryDto> Handle(GetWorkScheduleEntryByIdQuery request, CancellationToken cancellationToken)
        {
            var workScheduleEntry = await _workScheduleEntryRepository.GetByIdAsync(request.Id);
            return _mapper.Map<WorkScheduleEntryDto>(workScheduleEntry);
        }
    }
}
