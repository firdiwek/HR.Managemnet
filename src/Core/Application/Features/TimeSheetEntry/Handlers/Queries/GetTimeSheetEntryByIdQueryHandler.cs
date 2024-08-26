using System.Threading;
using System.Threading.Tasks;
using Application.Features.TimeSheetEntries.Requests.Queries;
using HR.Management.Application.DTOs;
using MediatR;
using AutoMapper;
using Application.Contracts.Persistance;

namespace Application.Features.TimeSheetEntries.Handlers.Queries
{
    public class GetTimeSheetEntryByIdQueryHandler : IRequestHandler<GetTimeSheetEntryByIdQuery, TimeSheetEntryDto>
    {
        private readonly ITimeSheetEntryRepository _timeSheetEntryRepository;
        private readonly IMapper _mapper;

        public GetTimeSheetEntryByIdQueryHandler(ITimeSheetEntryRepository timeSheetEntryRepository, IMapper mapper)
        {
            _timeSheetEntryRepository = timeSheetEntryRepository;
            _mapper = mapper;
        }

        public async Task<TimeSheetEntryDto> Handle(GetTimeSheetEntryByIdQuery request, CancellationToken cancellationToken)
        {
            var timeSheetEntry = await _timeSheetEntryRepository.GetByIdAsync(request.Id);
            return _mapper.Map<TimeSheetEntryDto>(timeSheetEntry);
        }
    }
}
