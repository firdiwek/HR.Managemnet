using MediatR;

namespace Application.Features.TimeSheets.Commands
{
    public class DeleteTimeSheetCommand : IRequest<bool>
    {
        public int Id { get; set; } // ID of the timesheet record to delete
    }
}
