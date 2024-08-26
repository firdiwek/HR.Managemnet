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
    public class GetAllLeaveRequestsQueryHandler : IRequestHandler<GetAllLeaveRequestsQuery, List<LeaveRequestDto>>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public GetAllLeaveRequestsQueryHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;

        }

        public async Task<List<LeaveRequestDto>> Handle(GetAllLeaveRequestsQuery request, CancellationToken cancellationToken)
        {
           var LeaveRequest = await _leaveRequestRepository.GetAllAsync();
           return _mapper.Map<List<LeaveRequestDto>>(LeaveRequest);
        }
    }
    
}