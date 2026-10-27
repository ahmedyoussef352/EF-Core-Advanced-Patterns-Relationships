using Microsoft.EntityFrameworkCore;

namespace EfCore2;

public class Customer
{
    public int Id { get; set; }

    public string Name { get; set; } = default!;

    public string? Email { get; set; } = default!;
    public ICollection<Order> orders { get; set; } = [];
    public ICollection<CustomerCustomerService> CustomerCustomerServices { get; set; } = [];
}

public class CustomerService
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;

    public ICollection<CustomerCustomerService> CustomerCustomerServices { get; set; } = [];
}

public class CustomerCustomerService
{
    public int Id { get; set; }

    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;

    public int CustomerServiceId { get; set; }
    public CustomerService CustomerService { get; set; } = null!;

    public DateTime SubscribeAt { get; set; }
}
public class Order
{
    public int Id { get; set; }

    public DateTime Date { get; set; }
    [Precision(10, 2)]
    public decimal TotalAmount { get; set; }
    public Customer customer { get; set; } = null!;
    public int? customerId { get; set; }
}

