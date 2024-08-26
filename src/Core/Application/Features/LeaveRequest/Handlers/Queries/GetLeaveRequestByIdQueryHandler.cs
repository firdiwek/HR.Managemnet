using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.Persistance;
using Application.Features.LeaveRequest.Requests.Queries;
using AutoMapper;
using HR.Management.Application.DTOs;
using MediatR;

namespace Application.Features.LeaveRequest.Handlers.Queries
{
    public class GetLeaveRequestByIdQueryHandler : IRequestHandler< GetLeaveRequestByIdQuery, LeaveRequestDto>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public GetLeaveRequestByIdQueryHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        public async Task<LeaveRequestDto> Handle(GetLeaveRequestByIdQuery request, CancellationToken cancellationToken)
        {
           var LeaveRequest = await _leaveRequestRepository.GetByIdAsync(request.Id);
           return _mapper.Map<LeaveRequestDto>(LeaveRequest);
        }
    }
    
}