using EfCore;

namespace EfCore2.SeedData;

public static class Seeder
{
    public static async Task SeedAllAsync(ApplicationDbContext dbContext)
    {
        await EmployeeSeeder.SeedAsynce(dbContext);
    }
}
