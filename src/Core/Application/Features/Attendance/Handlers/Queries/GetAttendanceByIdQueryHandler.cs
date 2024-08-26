using System.Threading;
using System.Threading.Tasks;
using HR.Management.Application.DTOs;
using MediatR;
using AutoMapper;
using Application.Features.Attendance.Handlers.Queries;
using Application.Contracts.Persistance;

namespace Application.Features.Attendances.Handlers.Queries
{
    public class GetAttendanceByIdQueryHandler : IRequestHandler<GetAttendanceByIdQuery, AttendanceDto>
    {
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly IMapper _mapper;

        public GetAttendanceByIdQueryHandler(IAttendanceRepository attendanceRepository, IMapper mapper)
        {
            _attendanceRepository = attendanceRepository;
            _mapper = mapper;
        }

        public async Task<AttendanceDto> Handle(GetAttendanceByIdQuery request, CancellationToken cancellationToken)
        {
            var attendance = await _attendanceRepository.GetByIdAsync(request.Id);
            return _mapper.Map<AttendanceDto>(attendance);
        }
    }
}
