using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HR.Management.Application.DTOs;
using MediatR;
using Application.Features.Departement.Requests.Queries;
using Application.Contracts.Persistance;

namespace Application.Features.Departments.Handlers.Queries
{
    public class GetAllDepartmentsQueryHandler : IRequestHandler<GetAllDepartmentsQuery, List<DepartmentDto>>
    {
        private readonly IDepartementRepository _departmentRepository;
        private readonly IMapper _mapper;

        public GetAllDepartmentsQueryHandler(IDepartementRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<List<DepartmentDto>> Handle(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
        {
            var departments = await _departmentRepository.GetAllAsync();
            return _mapper.Map<List<DepartmentDto>>(departments);
        }
    }
}
