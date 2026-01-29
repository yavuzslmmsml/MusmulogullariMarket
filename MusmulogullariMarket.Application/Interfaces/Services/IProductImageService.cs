using MusmulogullariMarket.Application.DTOs.ProductImages;

namespace MusmulogullariMarket.Application.Interfaces.Services;

public interface IProductImageService
{
    Task<List<ProductImageDto>> GetByProductIdAsync(Guid productId);
    Task AddAsync(CreateProductImageDto dto);
    Task DeleteAsync(Guid id);
}
