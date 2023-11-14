﻿using HR.LeaveManagement.Persistence.DatabaseContext;
using HRLeaveManagementApplication.Contracts.Persistance;
using HRLeaveManagementDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistence.Repositories
{
    internal class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        public LeaveAllocationRepository(HrDatabaseContext context) : base(context)
        {
        }
    }
}