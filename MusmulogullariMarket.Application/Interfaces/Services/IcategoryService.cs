using MusmulogullariMarket.Application.DTOs.Categories;
using MusmulogullariMarket.Domain.Entities;

namespace MusmulogullariMarket.Application.Interfaces.Services;

public interface ICategoryService
{
    Task<List<CategoryDto>> GetAllAsync();
    Task<Category?> GetByIdAsync(Guid id);
    Task CreateAsync(CreateCategoryDto dto);
    Task UpdateAsync(Guid id, UpdateCategoryDto dto);
    Task DeleteAsync(Guid id);
}
