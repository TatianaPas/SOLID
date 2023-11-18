using AutoMapper;
using HRLeaveManagementApplication.Features.LeaveType.Commands.CreateLeaveType;
using HRLeaveManagementApplication.Features.LeaveType.Commands.UpdateLeaveType;
using HRLeaveManagementApplication.Features.LeaveType.Queries.GetAllLeaveTpe;
using HRLeaveManagementApplication.Features.LeaveType.Queries.GetLeaveTypeDetails;
using HRLeaveManagementDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagementApplication.MappingProfiles
{
    public class LeaveTypeProfile : Profile
    {
        public LeaveTypeProfile()
        {
            CreateMap<LeaveTypeDto, LeaveType>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeDetailsDto>();
            CreateMap<CreateLeaveTypeCommand, LeaveType>();
            CreateMap<UpdateLeaveTypeCommand, LeaveType>();
        }
    }
}
