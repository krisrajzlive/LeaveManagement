using LeaveManagement.Contracts;
using LeaveManagement.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeaveManagement.Repository
{
    public class LeaveAllocationRepository : ILeaveAllocationRepository
    {
        private readonly ApplicationDbContext _db;

        public LeaveAllocationRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool CheckAllocation(int leavetypeid, string employeeid)
        {
            var period = DateTime.Now.Year;
            return FindAll().Where(a=> a.EmployeeId == employeeid && a.LeaveTypeId == leavetypeid && a.Period == period).Any();
        }

        public bool Create(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Add(entity);
            return Save();
        }

        public bool Delete(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Remove(entity);
            return Save();
        }

        public ICollection<LeaveAllocation> FindAll()
        {
            return _db.LeaveAllocations.Include(la=>la.LeaveType).ToList();
        }

        public LeaveAllocation FindById(int id)
        {
            return _db.LeaveAllocations
                .Include(la => la.LeaveType)
                .Include(la => la.Employee)
                .FirstOrDefault( la => la.Id == id);
        }

        public ICollection<LeaveAllocation> GetLeaveAllocationsByEmployee(string id)
        {
            var period = DateTime.Now.Year;

            return FindAll()
                .Where(la => la.EmployeeId == id && la.Period == period)
                .ToList();
        }

        public bool isExists(int id)
        {
            var exists = _db.LeaveAllocations.Any(l => l.Id == id);
            return exists;
        }

        public bool Save()
        {
            return _db.SaveChanges() > 0;
        }

        public bool Update(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Update(entity);
            return Save();
        }
    }
}
