using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistance;
using MediatR;
using HR.Management.Domain;
using Application.Features.Departement.Requests.Command; // Import the correct domain class

namespace Application.Features.Departments.Handlers.Commands
{
    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, int>
    {
        private readonly IDepartementRepository _departmentRepository;

        public CreateDepartmentCommandHandler(IDepartementRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<int> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = new Department // Use the correct class name
            {
                Name = request.Name,
                Description = request.Description,
                Budget = request.Budget
            };

            await _departmentRepository.AddAsync(department);
            return department.Id;
        }
    }
}
