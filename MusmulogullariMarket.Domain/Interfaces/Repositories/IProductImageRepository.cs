using MusmulogullariMarket.Domain.Entities;

namespace MusmulogullariMarket.Domain.Interfaces.Repositories;

public interface IProductImageRepository
{
    Task<List<ProductImage>> GetByProductIdAsync(Guid productId);
    Task<ProductImage?> GetByIdAsync(Guid id);
    Task AddAsync(ProductImage image);
    void Delete(ProductImage image);
}
