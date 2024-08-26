using MediatR;
using System;

namespace Application.Features.WorkScheduleEntries.Commands
{
    public class CreateWorkScheduleEntryCommand : IRequest<int>
    {
        public int WorkScheduleId { get; set; } // ID of the associated WorkSchedule
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string ShiftType { get; set; } = string.Empty; // E.g., Morning, Evening
    }
}
