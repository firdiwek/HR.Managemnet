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
    public class GetLeaveTypeByIdQueryHandler : IRequestHandler<GetLeaveTypeByIdQuery, LeaveTypeDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public GetLeaveTypeByIdQueryHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<LeaveTypeDto> Handle(GetLeaveTypeByIdQuery request, CancellationToken cancellationToken)
        {
           var leaveType = await _leaveTypeRepository.GetByIdAsync(request.Id);
           return _mapper.Map<LeaveTypeDto>(leaveType);
        }
    }
}