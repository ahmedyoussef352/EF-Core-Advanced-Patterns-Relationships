using EfCore;

Console.WriteLine("Hello");

using var dbContext = new ApplicationDbContext();

//var changeTracker = dbContext.ChangeTracker;

//var employee = new Employee
//{
//    1,
//    Name = "Ali"
//};
//if (employee == null)
//{
//    Console.WriteLine("Employee Not Found");
//    return;
//}
//dbContext.Employees.Update(employee);

//var employee = await dbContext.Employees
//    .FindAsync(1);
//if (employee == null)
//{
//    Console.WriteLine("Employee Not Found");
//    return;
//}

//dbContext.Employees.Remove(employee);
//await dbContext.SaveChangesAsync();


//int affect = await dbContext.Employees
//    .Where(e => e.Name.StartsWith("A"))
//    .ExecuteUpdateAsync(e =>
//    e.SetProperty(e => e.Salary, 20));


//await dbContext.Database.MigrateAsync();
//await Seeder.SeedAllAsync(dbContext);

//Session 4 

//var order = await dbContext.Orders
//    .Include(o => o.customer)
//    .FirstOrDefaultAsync(c => c.Id == 10);

//if (order != null)
//{
//    Console.WriteLine(order.Id);
//    Console.WriteLine(order.Date);
//    Console.WriteLine(order.customerId);
//    Console.WriteLine(order.customer.Name);
//    Console.WriteLine(order.customer.Email);

//}

/* Eager Loading
var customer = await dbContext.Cutsomers
    .Include(o => o.orders)
    .Include(c => c.CustomerCustomerServices)
    .FirstOrDefaultAsync(c => c.Id == 17);

if (customer != null)
{
    Console.WriteLine(customer.Id);
    Console.WriteLine(customer.Name);

    Console.WriteLine(customer.orders.Count);
    Console.WriteLine(customer.CustomerCustomerServices.Count);

}

foreach (var item in customer.orders)
{
    Console.WriteLine(item.TotalAmount);
}

var customer = await dbContext.Cutsomers
    .Include(o => o.orders
    .Where(o => o.TotalAmount > 100)
    .OrderByDescending(o => o.TotalAmount)
    .Take(3)
    ).ToListAsync();



*/
/* Select
var cutsoner = dbContext.Cutsomers
    .Select(c => new
    {
        c.Id,
        c.Name,
        orderCount = c.orders.Count,
        CustomerServiceCount = c.CustomerCustomerServices.Count,
        CustomerCustomerService = c.CustomerCustomerServices
                .Select(cs => new
                {
                    cs.CustomerService.Title
                }).ToList()

    }).FirstOrDefaultAsync(c => c.Id == 17);*/


/* Eager Loading
 * var customersWithOrders = await dbContext.Cutsomers // Ensure your DbSet name matches your DbContext (Customers or customers)
//    .Include(c => c.orders) // Eagerly load the related orders
//    .ToListAsync();

//foreach (var customer in customersWithOrders)
//{
//    Console.WriteLine($"----------------------------------------");
//    Console.WriteLine($"Customer Name: {customer.Name} (Email: {customer.Email})");
//    Console.WriteLine($"Total Orders: {customer.orders.Count}");

//    if (customer.orders.Any())
//    {
//        Console.WriteLine("Orders:");
//        foreach (var order in customer.orders)
//        {
//            Console.WriteLine($"  - Order ID: {order.Id} | Date: {order.Date.ToShortDateString()} | Amount: {order.TotalAmount:C}");
//        }
//    }
//    else
//    {
//        Console.WriteLine("  - No orders found for this customer.");
//    }
//}*/

/*Explicit

bool userRequestedOrders = true;

var customers2 = await dbContext.Cutsomers
                .FirstOrDefaultAsync(c => c.Id == 17);

if (customers2 != null && userRequestedOrders == true)
{
    await dbContext.Entry(customers2)
        .Collection(c => c.orders)
        .LoadAsync();
    Console.WriteLine($"OrderCount: {customers2.orders.Count}");
    Console.WriteLine($"Name: {customers2.Name}");
    foreach (var item in customers2.orders)
    {

        Console.WriteLine($"OrderDate: {item.Date}");
        Console.WriteLine($"Order TotalAmount : {item.TotalAmount}");
    }
}*/

/* TPH 
 * var f = new PartTimeEmployee
//{
//    Name = "Ali",
//    Salary = 200,
//    HourlyRate = 10

//};
//dbContext.Employees.Add(f);
//await dbContext.SaveChangesAsync();*/

/* TPT
var fullTime = new FullTimeEmployee
{
    Name = "Ahemd",
    Salary = 50,
    Salary2 = 60
};

var partTime = new PartTimeEmployee
{
    Name = "Mona",
    HourlyRate = 5,
    Salary = 70,
};

dbContext.FullTimeEmployees.Add(fullTime);
dbContext.PartTimeEmployees.Add(partTime);
await dbContext.SaveChangesAsync();*/


/* TPC
var full = new FullTimeEmployee
{
    Name = "AMR",
    Salary = 70,
    Salary2 = 80
};
dbContext.FullTimeEmployees.Add(full);
await dbContext.SaveChangesAsync();

//var fullTime = await dbContext.FullTimeEmployees
//    .ToListAsync();*/

//var result = await (from o in dbContext.Orders
//                    join c in dbContext.Cutsomers
//                    on o.customerId equals c.Id
//                    select new
//                    {
//                        orderId = o.Id,
//                        CustomerName = c.Name,
//                    }).ToListAsync();


//var result2 = await dbContext.Orders.Join(
//    dbContext.Cutsomers,
//    o => o.customerId,
//    c => c.Id,
//    (o, c) => new
//    {
//        orderId = o.Id,
//        CustomerName = c.Name,

//    }
//    ).ToListAsync();

/* Gruop 
var result = await dbContext.Cutsomers
    .GroupJoin(
        dbContext.Orders,
        o => o.Id,
        c => c.customerId,
        (o, c) => new
        {
            o,
            c
        }

    ).ToListAsync();*/

/* LeftJoin
var result = await dbContext.Cutsomers
    .LeftJoin(
        dbContext.Orders,
        o => o.Id,
        c => c.customerId,
        (o, c) => new
        {
            orderId = o != null ? o.Id : (int?)null,
        }

    ).ToListAsync();*/

/* CrossJoin 
 * var result = dbContext.Cutsomers
    .SelectMany(
    c => dbContext.Orders,
    (c, o) => new
    {
        orderId = o.Id,
        CustomerName = c.Name,
    }
    ).ToListAsync();*/