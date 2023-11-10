using AutoMapper;
using HRLeaveManagementApplication.Contracts.Persistance;
using HRLeaveManagementApplication.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagementApplication.Features.LeaveType.Commands.DeleteLeaveType
{
    internal class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository) =>
            this._leaveTypeRepository = leaveTypeRepository;

        public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            //retrive domain entity object
            var leaveTypeToDelete = await _leaveTypeRepository.GetByIdAsync(request.Id);

            //verify that record exists
            if (leaveTypeToDelete == null) 
                throw new NotFoundException(nameof(LeaveType), request.Id);

            //delete record
            await _leaveTypeRepository.DeleteAsync(leaveTypeToDelete);

            //return unit
            return Unit.Value;
        }
    }
}
