using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagementApplication.Features.LeaveType.Queries.GetAllLeaveTpe
{
    public record GetLeaveTypesQuery : IRequest<List<LeaveTypeDetailsDto>>;
}
