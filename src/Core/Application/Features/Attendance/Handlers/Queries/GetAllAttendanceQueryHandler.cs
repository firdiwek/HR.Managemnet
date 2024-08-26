
using AutoMapper;

using HR.Management.Application.DTOs;
using MediatR;
using Application.Features.Attendance.Requests.Queries;
using Application.Contracts.Persistance;

namespace Application.Features.Attendances.Handlers.Queries
{
    public class GetAllAttendanceQueryHandler : IRequestHandler<GetAllAttendanceQuery, List<AttendanceDto>>
    {
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly IMapper _mapper;

        public GetAllAttendanceQueryHandler(IAttendanceRepository attendanceRepository, IMapper mapper)
        {
            _attendanceRepository = attendanceRepository;
            _mapper = mapper;
        }

        public async Task<List<AttendanceDto>> Handle(GetAllAttendanceQuery request, CancellationToken cancellationToken)
        {
            var attendances = await _attendanceRepository.GetAllAsync();
            return _mapper.Map<List<AttendanceDto>>(attendances);
        }
    }
}
