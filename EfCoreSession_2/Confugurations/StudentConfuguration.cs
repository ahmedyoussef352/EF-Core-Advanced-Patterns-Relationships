using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCore2.Confugurations;

public class StudentConfuguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {



        //builder.ToTable("Students", "edu", t =>
        //{
        //    t.HasCheckConstraint("CK_Students_Age", "[Age] BETWEEN 10 AND 50");
        //});


        //builder.HasKey(s => s.Id);
        //builder.Property(s => s.FirstName)
        //.HasMaxLength(50);

        //builder.Property(s => s.EnrollmentDate)
        //    .HasDefaultValueSql("GETDATE()");

        ////builder.HasIndex(s => s.Email)
        ////    .IsUnique()
        ////    .HasFilter("[Email] IS NOT NULL")
        ////    .HasDatabaseName("IX_Student_Email");

        //builder.HasAlternateKey(s => s.Email);
    }
}

