using Microsoft.EntityFrameworkCore;
using MusmulogullariMarket.Domain.Entities;
using MusmulogullariMarket.Domain.Interfaces.Repositories;
using MusmulogullariMarket.Infrastructure.Persistence.Context;

namespace MusmulogullariMarket.Infrastructure.Repositories;

public class ProductImageRepository : IProductImageRepository
{
    private readonly AppDbContext _context;

    public ProductImageRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<ProductImage>> GetByProductIdAsync(Guid productId)
    {
        return await _context.ProductImages
            .Where(pi => pi.ProductId == productId)
            .ToListAsync();
    }

    public async Task<ProductImage?> GetByIdAsync(Guid id)
    {
        return await _context.ProductImages
            .FirstOrDefaultAsync(pi => pi.Id == id);
    }

    public async Task AddAsync(ProductImage image)
    {
        await _context.ProductImages.AddAsync(image);
        await _context.SaveChangesAsync();
    }

    public void Delete(ProductImage image)
    {
        _context.ProductImages.Remove(image);
        _context.SaveChanges();
    }
}
