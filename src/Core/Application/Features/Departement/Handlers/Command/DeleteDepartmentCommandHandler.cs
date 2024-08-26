
using Application.Contracts.Persistance;
using MediatR;

namespace Application.Features.Departments.Commands
{
    public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand, bool>
    {
        private readonly IDepartementRepository _departmentRepository;

        public DeleteDepartmentCommandHandler(IDepartementRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<bool> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = await _departmentRepository.GetByIdAsync(request.Id);
            if (department == null)
            {
                return false; // Department not found
            }

            await _departmentRepository.DeleteAsync(request.Id);

            return true;
        }
    }
}
