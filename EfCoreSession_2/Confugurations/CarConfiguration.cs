using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCore2.Confugurations;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.HasIndex(e => e.EmployeeId)
            .IsUnique()
            .HasFilter("[EmployeeId] Is Not Null");
        //builder.HasOne(d => d.Department)
        //.WithOne(e => e.Manager)
        //.HasForeignKey<Employee>(d => d.DepartmentId);
    }
}
