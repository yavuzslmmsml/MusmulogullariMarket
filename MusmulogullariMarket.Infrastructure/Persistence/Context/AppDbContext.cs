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
    public DbSet<ProductImage> ProductImages { get; set; }
    public DbSet<Category> Categories => Set<Category>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ProductImage>(builder =>
        {
            builder.ToTable("ProductImages");

            builder.HasKey(pi => pi.Id);

            builder.Property(pi => pi.ImagePath)
                .IsRequired()
                .HasMaxLength(300);

            builder.HasOne(pi => pi.Product)
                .WithMany(p => p.Images)
                .HasForeignKey(pi => pi.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
    
}
