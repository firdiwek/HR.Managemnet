using MediatR;

namespace Application.Features.WorkScheduleEntries.Commands
{
    public class DeleteWorkScheduleEntryCommand : IRequest<bool>
    {
        public int Id { get; set; } // ID of the WorkScheduleEntry to delete
    }
}
