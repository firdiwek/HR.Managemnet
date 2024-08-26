using MediatR;
using System;
using System.Collections.Generic;

namespace Application.Features.WorkSchedules.Commands
{
    public class CreateWorkScheduleCommand : IRequest<int>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ShiftType { get; set; } = string.Empty;
        public int EmployeeId { get; set; } // ID of the employee associated with this work schedule
        public List<WorkScheduleEntryDto> WorkScheduleEntries { get; set; } = new List<WorkScheduleEntryDto>();
    }

    public class WorkScheduleEntryDto
    {
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string ShiftType { get; set; } = string.Empty;
    }
}
