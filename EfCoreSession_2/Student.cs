using Microsoft.EntityFrameworkCore;

namespace EfCore2;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Email { get; set; }
    public ICollection<StudentCourse> StudentCourse { get; set; } = [];
}
public class Course
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public int Credits { get; set; }
    [Precision(10, 2)]
    public decimal Price { get; set; }
    public Status Status { get; set; }
    public ICollection<StudentCourse> StudentCourse { get; set; } = [];

}

public class StudentCourse
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public Student Student { get; set; } = null!;
    public int CourseId { get; set; }
    public Course Course { get; set; } = null!;
    public int Degree { get; set; }
}

public enum Status
{
    publish = 1,
    Draft = 2,
    Archieve
}

