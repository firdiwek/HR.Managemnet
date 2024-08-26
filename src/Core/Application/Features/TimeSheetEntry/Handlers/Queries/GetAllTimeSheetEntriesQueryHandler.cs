using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Application.Features.TimeSheetEntries.Requests.Queries;
using HR.Management.Application.DTOs;
using MediatR;
using Application.Contracts.Persistance;

namespace Application.Features.TimeSheetEntries.Handlers.Queries
{
    public class GetAllTimeSheetEntriesQueryHandler : IRequestHandler<GetAllTimeSheetEntriesQuery, List<TimeSheetEntryDto>>
    {
        private readonly ITimeSheetEntryRepository _timeSheetEntryRepository;
        private readonly IMapper _mapper;

        public GetAllTimeSheetEntriesQueryHandler(ITimeSheetEntryRepository timeSheetEntryRepository, IMapper mapper)
        {
            _timeSheetEntryRepository = timeSheetEntryRepository;
            _mapper = mapper;
        }

        public async Task<List<TimeSheetEntryDto>> Handle(GetAllTimeSheetEntriesQuery request, CancellationToken cancellationToken)
        {
            var timeSheetEntries = await _timeSheetEntryRepository.GetAllAsync();
            return _mapper.Map<List<TimeSheetEntryDto>>(timeSheetEntries);
        }
    }
}
