using MediatR;

namespace Application.Features.TimeSheetEntries.Commands
{
    public class DeleteTimeSheetEntryCommand : IRequest<bool>
    {
        public int Id { get; set; } // ID of the time sheet entry record to delete
    }
}
