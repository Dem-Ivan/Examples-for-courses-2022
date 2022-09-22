using Microsoft.EntityFrameworkCore;
using Store.Db.Models;

namespace Store.Db;

public class StoreContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=store_prod;Username=postgres;Password=postgres");
    }

    public DbSet<Order> Orders { get; set; }
    public DbSet<Customer> Customers { get; set; }
}