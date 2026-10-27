

using EfCore2;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace EfCore;

public class ApplicationDbContext : DbContext
{
    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder)
    {

        optionsBuilder
            .UseSqlServer("Server=localhost\\SQLEXPRESS; Database=EfCore4; Trusted_Connection=True; TrustServerCertificate=True")
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging();

        // .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<Employee>()
            .UseTpcMappingStrategy();

        modelBuilder.HasSequence<int>("EmployeesTypeId")
            .StartsAt(1)
            .IncrementsBy(1);

        modelBuilder.Entity<FullTimeEmployee>()
            .Property(e => e.Id)
            .HasDefaultValueSql("NEXT VALUE FOR EmployeesTypeId");

        modelBuilder.Entity<PartTimeEmployee>()
            .Property(e => e.Id)
            .HasDefaultValueSql("NEXT VALUE FOR EmployeesTypeId");


        /* TPT
        modelBuilder.Entity<Employee>()
            .UseTptMappingStrategy();*/

        /* TPH
         * 
         * modelBuilder.Entity<Employee>()
        .HasDiscriminator<string>("EmployeeType")
        .HasValue<Employee>("Employee")
        .HasValue<FullTimeEmployee>("FullTime")
        .HasValue<PartTimeEmployee>("PartTime");*/

        //modelBuilder.Entity<Department>()
        //.HasOne(d => d.Manager)                  // القسم له Manager (Employee)
        //.WithOne(e => e.ManagedDepartment)       // الموظف يدير ManagedDepartment
        //.HasForeignKey<Employee>(e => e.ManagedDepartmentId);

        //modelBuilder
        //    .Entity<Student>(entity =>
        //    {
        //        entity.ToTable("Students", "edu", t =>
        //        {
        //            t.HasCheckConstraint("CK_Students_Age", "[Age] BETWEEN 10 AND 50");
        //        });


        //        entity.HasKey(s => s.Id);
        //        entity.Property(s => s.FirstName)
        //        .HasMaxLength(50);

        //        entity.Property(s => s.EnrollmentDate)
        //            .HasDefaultValueSql("GETDATE()");

        //        //entity.HasIndex(s => s.Email)
        //        //    .IsUnique()
        //        //    .HasFilter("[Email] IS NOT NULL")
        //        //    .HasDatabaseName("IX_Student_Email");

        //        entity.HasAlternateKey(s => s.Email);
        //    });

        //modelBuilder.Entity<Course>(entity =>
        //{
        //    entity.Property(c => c.Status)
        //    .HasConversion<string>()
        //    .HasMaxLength(20);
        //});

    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<FullTimeEmployee> FullTimeEmployees { get; set; }
    public DbSet<PartTimeEmployee> PartTimeEmployees { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Customer> Cutsomers { get; set; }

    public DbSet<CustomerService> CustomerServices { get; set; }

    public DbSet<CustomerCustomerService> CustomerCustomerServices { get; set; }

    //public DbSet<Department> Departments { get; set; }

    public DbSet<Order> Orders { get; set; }
    public DbSet<StudentCourse> StudentCourses { get; set; }

}
