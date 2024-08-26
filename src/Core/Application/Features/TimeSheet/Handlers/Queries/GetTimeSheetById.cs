using System.Threading;
using System.Threading.Tasks;
using Application.Features.TimeSheets.Requests.Queries;
using HR.Management.Application.DTOs;
using MediatR;
using AutoMapper;
using Application.Contracts.Persistance;

namespace Application.Features.TimeSheets.Handlers.Queries
{
    public class GetTimeSheetByIdQueryHandler : IRequestHandler<GetTimeSheetByIdQuery, TimeSheetDto>
    {
        private readonly ITimeSheetRepository _timeSheetRepository;
        private readonly IMapper _mapper;

        public GetTimeSheetByIdQueryHandler(ITimeSheetRepository timeSheetRepository, IMapper mapper)
        {
            _timeSheetRepository = timeSheetRepository;
            _mapper = mapper;
        }

        public async Task<TimeSheetDto> Handle(GetTimeSheetByIdQuery request, CancellationToken cancellationToken)
        {
            var timeSheet = await _timeSheetRepository.GetByIdAsync(request.Id);
            return _mapper.Map<TimeSheetDto>(timeSheet);
        }
    }
}
