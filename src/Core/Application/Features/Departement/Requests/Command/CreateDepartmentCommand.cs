
using MediatR;

namespace Application.Features.Departement.Requests.Command
{
    public class CreateDepartmentCommand : IRequest<int>
    {
        public string Name { get; set; }=string.Empty;
        public string Description { get; set; }=string.Empty;
        public decimal Budget { get; set; }
        
    }
}