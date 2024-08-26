using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistance;
using Application.Features.Attendance.Commands;
using HR.Management.Domain;
using MediatR;

namespace Application.Features.Attendance.Handlers.Commands
{
    public class UpdateAttendanceCommandHandler : IRequestHandler<UpdateAttendanceCommand, bool>
    {
        private readonly IAttendanceRepository _attendanceRepository;

        public UpdateAttendanceCommandHandler(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        public async Task<bool> Handle(UpdateAttendanceCommand request, CancellationToken cancellationToken)
        {
            var attendance = await _attendanceRepository.GetByIdAsync(request.Id);
            if (attendance == null)
            {
                return false; // Attendance record not found
            }

            // Update the attendance record
            attendance.Date = request.Date;
            attendance.ClockInTime = request.ClockInTime;
            attendance.ClockOutTime = request.ClockOutTime;
            attendance.BreakStartTime = request.BreakStartTime;
            attendance.BreakEndTime = request.BreakEndTime;
            attendance.Status = request.Status;

            await _attendanceRepository.UpdateAsync(attendance);
            return true;
        }
    }
}
