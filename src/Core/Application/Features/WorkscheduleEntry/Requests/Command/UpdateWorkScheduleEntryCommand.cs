using MediatR;
using System;

namespace Application.Features.WorkScheduleEntries.Commands
{
    public class UpdateWorkScheduleEntryCommand : IRequest<bool>
    {
        public int Id { get; set; } // ID of the WorkScheduleEntry to update
        public int WorkScheduleId { get; set; } // ID of the associated WorkSchedule
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string ShiftType { get; set; } = string.Empty; // E.g., Morning, Evening
    }
}
