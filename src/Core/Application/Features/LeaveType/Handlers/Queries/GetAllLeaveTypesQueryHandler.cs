using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.Persistance;
using Application.Features.LeaveType.Requests.Queries;
using AutoMapper;
using HR.Management.Application.DTOs;
using MediatR;

namespace Application.Features.LeaveType.Handlers.Queries
{
    public class GetAllLeaveTypesQueryHandler : IRequestHandler<GetAllLeaveTypesQuery, List<LeaveTypeDto>>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public GetAllLeaveTypesQueryHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<List<LeaveTypeDto>> Handle(GetAllLeaveTypesQuery request, CancellationToken cancellationToken)
        {
            var leaveType = await _leaveTypeRepository.GetAllAsync();
            return _mapper.Map< List<LeaveTypeDto>>(leaveType);
        }
    }
}