using MediatR;
using System;

namespace Application.Features.TimeSheetEntries.Commands
{
    public class UpdateTimeSheetEntryCommand : IRequest<bool>
    {
        public int Id { get; set; } // ID of the time sheet entry record to update
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public TimeSpan TotalHours { get; set; }
        public string Description { get; set; } = string.Empty;
        public int EmployeeId { get; set; } // ID of the employee associated with this time sheet entry
    }
}
