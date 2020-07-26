using LeaveManagement.Data;
using System.Collections.Generic;

namespace LeaveManagement.Contracts
{
    public interface ILeaveAllocationRepository : IRepositoryBase<LeaveAllocation>
    {
        bool CheckAllocation(int leavetypeid, string employeeid);
        ICollection<LeaveAllocation> GetLeaveAllocationsByEmployee(string id);
    }
}
