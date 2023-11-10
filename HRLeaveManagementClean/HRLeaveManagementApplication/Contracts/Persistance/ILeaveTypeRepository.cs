using HRLeaveManagementDomain;

namespace HRLeaveManagementApplication.Contracts.Persistance
{
    public interface ILeaveTypeRepository : IGenericRepository<LeaveType>
    {
        Task<bool> IsLeaveTypeUnique(string name);
    }

}