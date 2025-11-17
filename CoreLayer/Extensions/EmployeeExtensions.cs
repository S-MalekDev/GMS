using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Extensions
{
    public static class EmployeeExtensions
    {
        public static void UpdateFrom(this Employee employee, Employee employeeToUpdate)
        {
            if (employee == null) throw new ArgumentNullException();

            employee.EmployeeId = employeeToUpdate.EmployeeId;
            employee.PersonId = employeeToUpdate.PersonId;
            employee.JobId = employeeToUpdate.JobId;
            employee.CreatedByUserId = employeeToUpdate.CreatedByUserId;
            employee.HireDate = employeeToUpdate.HireDate;
            employee.EndDate = employeeToUpdate.EndDate;
            employee.Salary = employeeToUpdate.Salary;
            employee.IsActive = employeeToUpdate.IsActive;
            employee.IsDeleted = employeeToUpdate.IsDeleted;
        }
    }
}
