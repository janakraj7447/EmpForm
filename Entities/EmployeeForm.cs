using System;
using System.Collections.Generic;

namespace EmpForm.Entities;

public partial class EmployeeForm
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Phone { get; set; }

    public string Email { get; set; }
}
