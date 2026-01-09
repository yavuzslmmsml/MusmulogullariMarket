using Microsoft.EntityFrameworkCore;
using MusmulogullariMarket.Domain.Entities;

namespace MusmulogullariMarket.Infrastructure.Persistence.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    // Şimdilik örnek
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();
}
