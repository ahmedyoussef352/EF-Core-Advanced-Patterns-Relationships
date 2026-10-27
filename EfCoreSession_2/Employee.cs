using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCore2;


//public class Department
//{
//    public int Id { get; set; }
//    public string Title { get; set; } = default!;
//    public Employee Manager { get; set; } = default!;
//    public ICollection<Employee> Employees { get; set; } = [];
//}

public abstract class Employee
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [MaxLength(Constance.MaxNameLength)]
    public string Name { get; set; } = default!;
    [Precision(10, 2)]
    public decimal Salary { get; set; }
    public Car? Car { get; set; } = default!;

    //[InverseProperty(nameof(Department.Employees))]
    //public Department WorksIn { get; set; } = default!;
    //public int WorksInId { get; set; }

    //[InverseProperty(nameof(Department.Manager))]
    //    public Department Manger { get; set; } = default!;
    public int? MangerId { get; set; }
}

public class FullTimeEmployee : Employee
{
    [Precision(10, 2)]
    public decimal Salary2 { get; set; }
}


public class PartTimeEmployee : Employee
{
    [Precision(10, 2)]
    public decimal HourlyRate { get; set; }
}


public class Car
{
    public int Id { get; set; }
    public string Model { get; set; } = default!;
    public Employee Employee { get; set; } = default!;
    public int EmployeeId { get; set; } = default!;
}

public static class Constance
{
    public const int MaxNameLength = 100;
}