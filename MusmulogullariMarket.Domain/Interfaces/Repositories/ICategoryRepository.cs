using MusmulogullariMarket.Domain.Entities;

namespace MusmulogullariMarket.Domain.Interfaces.Repositories;

public interface ICategoryRepository
{
    Task<List<Category>> GetAllAsync();
    Task<Category?> GetByIdAsync(Guid id);
    Task AddAsync(Category category);
    void Update(Category category);
    void Delete(Category category);
}