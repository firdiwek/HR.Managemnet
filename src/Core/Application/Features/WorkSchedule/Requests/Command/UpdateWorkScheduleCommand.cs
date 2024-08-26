using MediatR;
using System;
using System.Collections.Generic;

namespace Application.Features.WorkSchedules.Commands
{
    public class UpdateWorkScheduleCommand : IRequest<bool>
    {
        public int Id { get; set; } // ID of the work schedule record to update
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ShiftType { get; set; } = string.Empty;
        public int EmployeeId { get; set; } // ID of the employee associated with this work schedule
        public List<WorkScheduleEntryDto> WorkScheduleEntries { get; set; } = new List<WorkScheduleEntryDto>();
    }
}
