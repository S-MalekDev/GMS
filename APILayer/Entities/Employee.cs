using System;
using System.Collections.Generic;

namespace APILayer.Entities;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public int PersonId { get; set; }

    public short JobId { get; set; }

    public int CreatedByUserId { get; set; }

    public DateOnly HireDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public decimal Salary { get; set; }

    public bool IsActive { get; set; }

    public bool? IsDeleted { get; set; }
}
