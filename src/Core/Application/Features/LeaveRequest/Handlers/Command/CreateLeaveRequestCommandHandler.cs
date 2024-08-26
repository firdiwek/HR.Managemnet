using Application.Contracts.Persistance;
using Application.Features.LeaveRequests.Commands;
using Domain;
using HR.Management.Domain;
using MediatR;


namespace Application.Features.LeaveRequests.Handlers.Commands
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, int>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
        }

        public async Task<int> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = new HR.Management.Domain.LeaveRequest
            {
                LeaveType = request.LeaveType,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Comments = request.Comments,
                Employee = new Employee { Id = request.EmployeeId } // Set the Employee navigation property
            };

            await _leaveRequestRepository.AddAsync(leaveRequest);
            return leaveRequest.Id;
        }
    }
}
