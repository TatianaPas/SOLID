using AutoMapper;
using HRLeaveManagementApplication.Features.LeaveType.Queries.GetAllLeaveTpe;
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
                CreateMap<LeaveTypeDetailsDto, LeaveType>().ReverseMap();
        }
    }
}
