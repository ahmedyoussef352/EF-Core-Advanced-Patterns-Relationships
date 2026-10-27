//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace EfCore2.Confugurations;

//public class CourseConfuguration : IEntityTypeConfiguration<Course>
//{
//    public void Configure(EntityTypeBuilder<Course> builder)
//    {

//        builder.Property(c => c.Status)
//            .HasConversion<string>()
//            .HasMaxLength(20);

//        builder
//            .Property(c => c.Id)
//            .HasDefaultValueSql("NEWID()"); // أو تركها ليولدها الكود في C#builder.Property(c => c.Id)

//    }
//}
