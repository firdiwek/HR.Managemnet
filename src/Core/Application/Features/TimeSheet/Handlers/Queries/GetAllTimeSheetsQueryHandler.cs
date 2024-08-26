using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;

using HR.Management.Application.DTOs;
using MediatR;
using Application.Features.TimeSheet.Requests.Queries;
using Application.Contracts.Persistance;

namespace Application.Features.TimeSheets.Handlers.Queries
{
    public class GetAllTimeSheetsQueryHandler : IRequestHandler<GetAllTimeSheetsQuery, List<TimeSheetDto>>
    {
        private readonly ITimeSheetRepository _timeSheetRepository;
        private readonly IMapper _mapper;

        public GetAllTimeSheetsQueryHandler(ITimeSheetRepository timeSheetRepository, IMapper mapper)
        {
            _timeSheetRepository = timeSheetRepository;
            _mapper = mapper;
        }

        public async Task<List<TimeSheetDto>> Handle(GetAllTimeSheetsQuery request, CancellationToken cancellationToken)
        {
            var timeSheets = await _timeSheetRepository.GetAllAsync();
            return _mapper.Map<List<TimeSheetDto>>(timeSheets);
        }
    }
}
