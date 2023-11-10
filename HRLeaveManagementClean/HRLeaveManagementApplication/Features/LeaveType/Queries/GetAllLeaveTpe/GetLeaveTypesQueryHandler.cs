using AutoMapper;
using HRLeaveManagementApplication.Contracts.Persistance;
using HRLeaveManagementApplication.Features.LeaveType.Queries.GetAllLeaveTpe;
using HRLeaveManagementApplication.Features.LeaveType.Queries.GetLeaveTypeDetails;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagementApplication.Features.LeaveType.Queries.GetAllLeaveTypes
{
    public class GetLeaveTypesQueryHandler : IRequestHandler<GetLeaveTypesQuery, List<LeaveTypeDetailsDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public GetLeaveTypesQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository )
        {
            this._mapper = mapper;
            this._leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<List<LeaveTypeDetailsDto>> Handle(GetLeaveTypesQuery request, CancellationToken cancellationToken)
        {

            //query the database
            var leaveTypes =await _leaveTypeRepository.GetAsync();

            //convert data objects to DTO objects
            var data = _mapper.Map<List<LeaveTypeDetailsDto>>(leaveTypes);

            //return list of DTO objects
            return data;

        }
    }
}
