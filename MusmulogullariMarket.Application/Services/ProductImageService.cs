using MusmulogullariMarket.Application.DTOs.ProductImages;
using MusmulogullariMarket.Application.Interfaces.Services;
using MusmulogullariMarket.Domain.Entities;
using MusmulogullariMarket.Domain.Interfaces.Repositories;

namespace MusmulogullariMarket.Application.Services;

public class ProductImageService : IProductImageService
{
    private readonly IProductImageRepository _imageRepository;

    public ProductImageService(IProductImageRepository imageRepository)
    {
        _imageRepository = imageRepository;
    }

    public async Task<List<ProductImageDto>> GetByProductIdAsync(Guid productId)
    {
        var images = await _imageRepository.GetByProductIdAsync(productId);

        return images.Select(img => new ProductImageDto
        {
            Id = img.Id,
            ProductId = img.ProductId,
            ImagePath = img.ImagePath
        }).ToList();
    }

    public async Task AddAsync(CreateProductImageDto dto)
    {
        var image = new ProductImage(dto.ProductId, dto.ImagePath);
        await _imageRepository.AddAsync(image);
    }

    public async Task DeleteAsync(Guid id)
    {
        var image = await _imageRepository.GetByIdAsync(id);
        if (image == null)
            return;

        _imageRepository.Delete(image);
    }
}
