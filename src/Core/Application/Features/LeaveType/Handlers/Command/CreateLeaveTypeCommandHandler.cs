using Application.Contracts.Persistance;
using Application.Features.LeaveTypes.Commands;
using Domain;
using MediatR;


namespace Application.Features.LeaveTypes.Handlers.Commands
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var leaveType = new HR.Management.Domain.LeaveType
            {
                Name = request.Name,
                Description = request.Description,
                MaxDays = request.MaxDays
            };

            await _leaveTypeRepository.AddAsync(leaveType);
            return leaveType.Id;
        }
    }
}
