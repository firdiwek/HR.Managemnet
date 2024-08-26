using MediatR;

namespace Application.Features.WorkSchedules.Commands
{
    public class DeleteWorkScheduleCommand : IRequest<bool>
    {
        public int Id { get; set; } // ID of the work schedule record to delete
    }
}
