namespace EfCore2.Confugurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {

        // 4. العلاقة مع Orders (One-to-Many)
        builder.HasMany(c => c.orders)
              .WithOne(o => o.customer)
              .HasForeignKey(o => o.customerId)
              .OnDelete(DeleteBehavior.Cascade); // أو Restrict حسب رغبتك في الحذف

        builder.HasMany(c => c.CustomerCustomerServices)
              .WithOne(cs => cs.Customer)
              .HasForeignKey(cs => cs.CustomerId)
              .OnDelete(DeleteBehavior.Cascade);
    }
}
public class CustomerServiceConfiguration : IEntityTypeConfiguration<CustomerService>
{
    public void Configure(EntityTypeBuilder<CustomerService> builder)
    {
        builder.HasKey(cs => cs.Id);

        builder.HasMany(cs => cs.CustomerCustomerServices)
              .WithOne(ccs => ccs.CustomerService)
              .HasForeignKey(ccs => ccs.CustomerServiceId)
              .OnDelete(DeleteBehavior.Cascade);
    }
}