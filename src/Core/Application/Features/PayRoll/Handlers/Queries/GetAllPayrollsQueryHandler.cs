using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.Persistance;
using Application.Features.PayRoll.Requests.Queries;
using AutoMapper;
using HR.Management.Application.DTOs;
using MediatR;

namespace Application.Features.PayRoll.Handlers.Queries
{
    public class GetAllPayrollsQueryHandler : IRequestHandler<GetAllPayrollsQuery, List<PayrollDto>>
    {
       private readonly IPayRollRepository _payRollRepository;
       private readonly IMapper _mapper;

        public GetAllPayrollsQueryHandler(IPayRollRepository payRollRepository, IMapper mapper)

        {
            _payRollRepository = payRollRepository;
            _mapper = mapper;
        }

        public async Task<List<PayrollDto>> Handle(GetAllPayrollsQuery request, CancellationToken cancellationToken)
        {
           var payRoll = await _payRollRepository.GetAllAsync();
           return _mapper.Map<List<PayrollDto>>(payRoll);
        }
    }
}