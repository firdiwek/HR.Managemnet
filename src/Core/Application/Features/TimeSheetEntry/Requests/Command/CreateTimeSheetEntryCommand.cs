using MediatR;
using System;

namespace Application.Features.TimeSheetEntries.Commands
{
    public class CreateTimeSheetEntryCommand : IRequest<int>
    {
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public TimeSpan TotalHours { get; set; }
        public string Description { get; set; } = string.Empty;
        public int EmployeeId { get; set; } // ID of the employee associated with this time sheet entry
    }
}
