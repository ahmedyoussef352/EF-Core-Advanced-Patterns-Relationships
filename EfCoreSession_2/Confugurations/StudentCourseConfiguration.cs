using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCore2.Confugurations;

public class StudentCourseConfiguration : IEntityTypeConfiguration<StudentCourse>
{
    public void Configure(EntityTypeBuilder<StudentCourse> builder)
    {
        builder.HasIndex(sc => new { sc.CourseId, sc.StudentId })
            .IsUnique();
    }
}
