using MediatR;
using System;

namespace Application.Features.TimeSheets.Commands
{
    public class UpdateTimeSheetCommand : IRequest<bool>
    {
        public int Id { get; set; } // ID of the timesheet record to update
        public DateTime Date { get; set; }
        public TimeSpan WorkedHours { get; set; }
        public string Notes { get; set; } = string.Empty;
        public int EmployeeId { get; set; } // ID of the employee associated with this timesheet
    }
}
