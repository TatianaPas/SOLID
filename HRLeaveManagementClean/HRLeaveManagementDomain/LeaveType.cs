using HRLeaveManagementDomain.Common;
using System.ComponentModel.DataAnnotations;

namespace HRLeaveManagementDomain;

public class LeaveType : BaseEntity
{
    [StringLength(50)]
    public string Name { get; set; } = string.Empty;
    public int DefaultDays { get; set; }
}
