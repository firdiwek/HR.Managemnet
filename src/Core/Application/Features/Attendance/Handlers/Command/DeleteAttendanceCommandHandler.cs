using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistance;
using Application.Features.Attendance.Commands;
using MediatR;

namespace Application.Features.Attendance.Handlers.Commands
{
    public class DeleteAttendanceCommandHandler : IRequestHandler<DeleteAttendanceCommand, bool>
    {
        private readonly IAttendanceRepository _attendanceRepository;

        public DeleteAttendanceCommandHandler(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        public async Task<bool> Handle(DeleteAttendanceCommand request, CancellationToken cancellationToken)
        {
            var attendance = await _attendanceRepository.GetByIdAsync(request.Id);
            if (attendance == null)
            {
                return false; // Attendance record not found
            }

           await _attendanceRepository.DeleteAsync(request.Id); // Pass the ID instead of the Attendance object
           return true;
        }
    }
}
