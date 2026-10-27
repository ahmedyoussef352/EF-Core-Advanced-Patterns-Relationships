using EfCore;
using System.Text.Json;

namespace EfCore2.SeedData;

public static class EmployeeSeeder
{

    public static async Task SeedAsynce(ApplicationDbContext dbContext)
    {
        var jsonPath = Path
            .Combine(AppContext.BaseDirectory, "SeedData", "Files", "EmpolyeesSeed.json");

        if (!File.Exists(jsonPath))
        {
            Console.WriteLine("File is not Exist");
            return;
        }

        var jsonContent = await File.ReadAllTextAsync(jsonPath);

        var employees = JsonSerializer
            .Deserialize<List<Employee>>(
         jsonContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        if (employees == null || !employees.Any())
        {

            Console.WriteLine("Failed");
            return;
        }
        //List<Employee> employees =
        //[
        //    new() { Name = "Samy",Salary = 50 },
        //    new() { Name = "Ahmed",Salary = 50 },
        //    new() { Name = "Mo",Salary = 50 },
        //    new() { Name = "Nader",Salary = 50 }
        //];

        await dbContext.Employees.AddRangeAsync(employees);
        await dbContext.SaveChangesAsync();
    }
}
