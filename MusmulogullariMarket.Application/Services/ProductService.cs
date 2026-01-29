using MusmulogullariMarket.Application.DTOs.Products;
using MusmulogullariMarket.Application.Interfaces.Services;
using MusmulogullariMarket.Domain.Entities;
using MusmulogullariMarket.Domain.Interfaces.Repositories;

namespace MusmulogullariMarket.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;

    public ProductService(
        IProductRepository productRepository,
        ICategoryRepository categoryRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<List<ProductDto>> GetAllAsync()
    {
        var products = await _productRepository.GetAllAsync();

        return products.Select(p => new ProductDto
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price,
            Stock = p.Stock,
            CategoryId = p.CategoryId,
            CategoryName = p.Category?.Name
        }).ToList();
    }

    public async Task<ProductDto?> GetByIdAsync(Guid id)
    {
        var product = await _productRepository.GetByIdAsync(id);

        if (product == null)
            return null;

        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Stock = product.Stock,
            CategoryId = product.CategoryId,
            CategoryName = product.Category?.Name
        };
    }

    public async Task CreateAsync(CreateProductDto dto)
    {
        // Önce kategori var mı kontrol edelim (domain güvenliği)
        var category = await _categoryRepository.GetByIdAsync(dto.CategoryId);
        if (category == null)
            throw new Exception("Kategori bulunamadı");

        var product = new Product(
            dto.Name,
            dto.Description,
            dto.Price,
            dto.Stock,
            dto.CategoryId
        );

        await _productRepository.AddAsync(product);
    }

    public async Task UpdateAsync(Guid id, UpdateProductDto dto)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null)
            return;

        // Domain metotlarını kullanıyoruz (DDD yaklaşımı)
        product.UpdatePrice(dto.Price);

        // Diğer alanları da güncelleyelim
        // (Bunlar için istersen ayrı domain metodları da yazabiliriz)
        typeof(Product)
            .GetProperty(nameof(Product.Name))?
            .SetValue(product, dto.Name);

        typeof(Product)
            .GetProperty(nameof(Product.Description))?
            .SetValue(product, dto.Description);

        typeof(Product)
            .GetProperty(nameof(Product.Stock))?
            .SetValue(product, dto.Stock);

        _productRepository.Update(product);
    }

    public async Task DeleteAsync(Guid id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null)
            return;

        _productRepository.Delete(product);
    }
}
