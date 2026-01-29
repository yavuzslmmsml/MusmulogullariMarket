using MusmulogullariMarket.Application.DTOs.Products;

namespace MusmulogullariMarket.Application.Interfaces.Services;

public interface IProductService
{
    Task<List<ProductDto>> GetAllAsync();
    Task<ProductDto?> GetByIdAsync(Guid id);
    Task CreateAsync(CreateProductDto dto);
    Task UpdateAsync(Guid id, UpdateProductDto dto);
    Task DeleteAsync(Guid id);
}
