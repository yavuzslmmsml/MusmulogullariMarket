using MusmulogullariMarket.Domain.Entities;
using MusmulogullariMarket.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;   // <-- BUNU EKLE ✅


namespace MusmulogullariMarket.Infrastructure.Persistence.Seed;

public static class DataSeeder
{
    public static void Seed(AppDbContext context)
{
    // 👇 BUNU DEĞİŞTİRİYORUZ
    context.Database.Migrate();

    if (!context.Categories.Any())
    {
        context.Categories.AddRange(
            new Category("Et ürünleri"),
            new Category("Yöresel ürünler"),
            new Category("Şarküteri")
        );

        context.SaveChanges();
    }
}

}
