using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HR.Management.Application.DTOs;
using MediatR;
using Application.Features.PayRoll.Requests.Queries;
using Application.Contracts.Persistance;

namespace Application.Features.Payrolls.Handlers.Queries
{
    public class GetAllPayrollsQueryHandler : IRequestHandler<GetAllPayrollsQuery, List<PayrollDto>>
    {
        private readonly IPayRollRepository _payrollRepository;
        private readonly IMapper _mapper;

        public GetAllPayrollsQueryHandler(IPayRollRepository payrollRepository, IMapper mapper)
        {
            _payrollRepository = payrollRepository;
            _mapper = mapper;
        }

        public async Task<List<PayrollDto>> Handle(GetAllPayrollsQuery request, CancellationToken cancellationToken)
        {
            var payrolls = await _payrollRepository.GetAllAsync();
            return _mapper.Map<List<PayrollDto>>(payrolls);
        }
    }
}
