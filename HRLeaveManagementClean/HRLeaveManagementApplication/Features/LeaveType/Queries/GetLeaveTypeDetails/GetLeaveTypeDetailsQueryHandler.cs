using AutoMapper;
using HRLeaveManagementApplication.Contracts.Persistance;
using HRLeaveManagementApplication.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagementApplication.Features.LeaveType.Queries.GetLeaveTypeDetails
{
    internal class GetLeaveTypeDetailsQueryHandler : IRequestHandler<GetLeaveTypeDetailsQuery, LeaveTypeDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public GetLeaveTypeDetailsQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            this._mapper = mapper;
            this._leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<LeaveTypeDetailsDto> Handle(GetLeaveTypeDetailsQuery request, CancellationToken cancellationToken)
        {
            //Queryable databae
            var leaveTypeDetal = await _leaveTypeRepository.GetByIdAsync(request.id);
            //verify that record exists
            if (leaveTypeDetal == null)
                throw new NotFoundException(nameof(LeaveType), request.id);

            //map to dto
            var data = _mapper.Map<LeaveTypeDetailsDto>(leaveTypeDetal);

            //return dto object
            return data;

        }
    }
}
