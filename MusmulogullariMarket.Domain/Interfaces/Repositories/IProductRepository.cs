using MusmulogullariMarket.Domain.Entities;

namespace MusmulogullariMarket.Domain.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(Guid id);
        Task<List<Product>> GetByCategoryIdAsync(Guid categoryId);
        Task AddAsync(Product product);
        void Update(Product product);
        void Delete(Product product);
    }
}