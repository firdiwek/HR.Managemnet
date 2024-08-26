using MediatR;
using System;

namespace Application.Features.TimeSheets.Commands
{
    public class CreateTimeSheetCommand : IRequest<int>
    {
        public DateTime Date { get; set; }
        public TimeSpan WorkedHours { get; set; }
        public string Notes { get; set; } = string.Empty;
        public int EmployeeId { get; set; } // ID of the employee associated with this timesheet
    }
}
