using CoreLayer.Entities;
using CoreLayer.Extensions;
using CoreLayer.Interfaces.IEmployee;
using DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            var employees = await _context.Employees.AsNoTracking()
                .Where(e => !e.IsDeleted)
                .Include(e => e.PersonInfo)
                .Include(e => e.CreatedBy)
                .Include(e => e.JobInfo)
                .ToListAsync();

            return employees;
        }

        public async Task<Employee?> GetByIdAsync(int employeeId)
        {
            var employee = await _context.Employees.AsNoTracking()
                .Include(e => e.PersonInfo)
                .Include(e => e.CreatedBy)
                .Include(e => e.JobInfo)
                .FirstOrDefaultAsync(e => e.EmployeeId == employeeId && !e.IsDeleted);

            return employee;
        }

        public async Task<int> AddAsync(Employee employeeToAdd)
        {
            await _context.Employees.AddAsync(employeeToAdd);
            await _context.SaveChangesAsync();
            return employeeToAdd.EmployeeId;
        }

        public async Task<bool> UpdateAsync(Employee employeeToUpdate)
        {
            var employeeFound = await _context.Employees
                .FirstOrDefaultAsync(e => e.EmployeeId == employeeToUpdate.EmployeeId && !e.IsDeleted);

            if (employeeFound != null)
            {
                employeeFound.JobId = employeeToUpdate.JobId;
                employeeFound.Salary = employeeToUpdate.Salary;
                employeeFound.IsActive = employeeToUpdate.IsActive;

                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteAsync(int employeeId)
        {
            var employeeFound = await _context.Employees.FindAsync(employeeId);

            if (employeeFound != null)
            {
                // NOTE: Soft delete handled by SQL Trigger (Instead Of Delete)
                _context.Employees.Remove(employeeFound);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> RestoreAsync(int personId)
        {
            var employeeFound = await _context.Employees
                .FirstOrDefaultAsync(e => e.PersonId == personId);

            if (employeeFound != null)
            {
                employeeFound.IsDeleted = false;
                await _context.SaveChangesAsync();      
                return true;
            }

            return false;
        }

        public async Task<bool> ExistsAsync(int userId)
        {
            var exists = await _context.Employees.AsNoTracking()
                .AnyAsync(e => e.EmployeeId == userId && !e.IsDeleted);

            return exists;
        }

        public async Task<bool> ExistsByPersonIdAsync(int personId)
        {
            var exists = await _context.Employees.AsNoTracking()
                .AnyAsync(e => e.PersonId == personId && !e.IsDeleted);

            return exists;
        }

        public async Task<bool> PersonHasDeletedEmployeeAsync(int personId)
        {
            var exists = await _context.Employees.AsNoTracking()
                .AnyAsync(e => e.PersonId == personId && e.IsDeleted);

            return exists;
        }

        public async Task<bool> PersonBeOrHaveBeEmployeeAsync(int personId)
        {
            var exists = await _context.Employees.AsNoTracking()
                .AnyAsync(e => e.PersonId == personId);

            return exists;
        }

        public async Task<bool> HasEmployeesLinkedToJobAsync(short jobId)
        {
            var isLinked = await _context.Employees.AsNoTracking()
                .AnyAsync(e => e.JobId == jobId);

            return isLinked;
        }
    }
}
