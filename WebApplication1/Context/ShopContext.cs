using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Context;

public class ShopContext : DbContext
{
    protected ShopContext()
    {
    }

    public ShopContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Client> Clients { get; set; } = null!;
    public DbSet<Discount> Discounts{ get; set; } = null!;
    public DbSet<Payment> Payments{ get; set; } = null!;
    public DbSet<Sale> Sales { get; set; } = null!;
    public DbSet<Subscription> Subscriptions{ get; set; } = null!;
}