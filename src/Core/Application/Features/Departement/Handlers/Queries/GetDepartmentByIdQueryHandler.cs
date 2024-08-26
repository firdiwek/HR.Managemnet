using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.Persistance;
using Application.Features.Departement.Requests.Queries;
using AutoMapper;
using HR.Management.Application.DTOs;
using MediatR;

namespace Application.Features.Departement.Handlers.Queries
{
    public class GetDepartmentByIdQueryHandler : IRequestHandler<GetDepartmentByIdQuery, DepartmentDto>
    {
        private readonly IDepartementRepository _departementRepository;
        private readonly IMapper _mapper;

        public GetDepartmentByIdQueryHandler(IDepartementRepository departementRepository, IMapper mapper)
        {
            _departementRepository = departementRepository;
            _mapper = mapper;
        }

        public async Task<DepartmentDto> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            var departement = await _departementRepository.GetByIdAsync(request.Id);
            return _mapper.Map<DepartmentDto>(departement);
        }
    }
}