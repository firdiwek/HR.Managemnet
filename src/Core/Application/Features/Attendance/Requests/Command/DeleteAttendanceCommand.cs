using MediatR;

namespace Application.Features.Attendance.Commands
{
    public class DeleteAttendanceCommand : IRequest<bool>
    {
        public int Id { get; set; } // ID of the attendance record to delete
    }
}
