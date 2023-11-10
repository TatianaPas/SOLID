using AutoMapper;
using HRLeaveManagementApplication.Contracts.Persistance;
using HRLeaveManagementApplication.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagementApplication.Features.LeaveType.Commands.CreateLeaveType
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            this._mapper = mapper;
            this._leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            //validate incoming data
            var validator = new CreateLeaveTypeCommandValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Any()) throw new BadRequestException("Invalid Leave Type", validationResult);


            //convert to domain entity object
            var leaveTypeToCreate = _mapper.Map<HRLeaveManagementDomain.LeaveType>(request);
            // add to database
            await _leaveTypeRepository.CreateAsync(leaveTypeToCreate);
            //return required id
            return leaveTypeToCreate.Id;
        }
    }
}
