using Application.Contracts.Persistance;
using Application.Features.Attendance.Commands;
using MediatR;

public class CreateAttendanceCommandHandler : IRequestHandler<CreateAttendanceCommand, int>
{
    private readonly IAttendanceRepository _attendanceRepository;
    private readonly IEmployeeRepository _employeeRepository; // Add repository for Employee

    public CreateAttendanceCommandHandler(IAttendanceRepository attendanceRepository, IEmployeeRepository employeeRepository)
    {
        _attendanceRepository = attendanceRepository;
        _employeeRepository = employeeRepository; // Initialize Employee repository
    }

    public async Task<int> Handle(CreateAttendanceCommand request, CancellationToken cancellationToken)
    {
        var employee = await _employeeRepository.GetByIdAsync(request.EmployeeId);
        if (employee == null)
        {
            throw new Exception("Employee not found"); // Handle missing employee case
        }

        var attendance = new HR.Management.Domain.Attendance
        {
            Date = request.Date,
            ClockInTime = request.ClockInTime,
            ClockOutTime = request.ClockOutTime,
            BreakStartTime = request.BreakStartTime,
            BreakEndTime = request.BreakEndTime,
            Status = request.Status,
            Employee = employee // Set the employee instance
        };

        await _attendanceRepository.AddAsync(attendance);
        return attendance.Id; // Return the ID of the created attendance record
    }
}
