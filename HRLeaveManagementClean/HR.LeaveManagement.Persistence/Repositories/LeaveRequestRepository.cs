using HR.LeaveManagement.Persistence.DatabaseContext;
using HRLeaveManagementApplication.Contracts.Persistance;
using HRLeaveManagementDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistence.Repositories
{
    internal class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        public LeaveRequestRepository(HrDatabaseContext context) : base(context)
        {
        }
    }
}
