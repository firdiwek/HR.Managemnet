using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistance;
using Domain;
using MediatR;

namespace Application.Features.Departments.Commands
{
    public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, bool>
    {
        private readonly IDepartementRepository _departmentRepository;

        public UpdateDepartmentCommandHandler(IDepartementRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<bool> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = await _departmentRepository.GetByIdAsync(request.Id);
            if (department == null)
            {
                return false; // Department not found
            }

            department.Name = request.Name;
            department.Description = request.Description;
            department.Budget = request.Budget;

            await _departmentRepository.UpdateAsync(department);

            return true;
        }
    }
}
