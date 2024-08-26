using MediatR;

namespace Application.Features.Departments.Commands
{
    public class UpdateDepartmentCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public string Description { get; set; }=string.Empty;
        public decimal Budget { get; set; }
    }
}
