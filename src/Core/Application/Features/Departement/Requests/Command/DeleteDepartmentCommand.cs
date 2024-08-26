using MediatR;

namespace Application.Features.Departments.Commands
{
    public class DeleteDepartmentCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
