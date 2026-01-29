using AutoMapper;
using MusmulogullariMarket.Application.DTOs.Categories;
using MusmulogullariMarket.Application.Interfaces.Services;
using MusmulogullariMarket.Domain.Entities;
using MusmulogullariMarket.Domain.Interfaces.Repositories;

namespace MusmulogullariMarket.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<List<CategoryDto>> GetAllAsync()
    {
        var categories = await _categoryRepository.GetAllAsync();

        return _mapper.Map<List<CategoryDto>>(categories);
    }

    public async Task<Category?> GetByIdAsync(Guid id)
    {
        return await _categoryRepository.GetByIdAsync(id);
    }

    public async Task CreateAsync(CreateCategoryDto dto)
    {
        var category = _mapper.Map<Category>(dto);

        await _categoryRepository.AddAsync(category);
    }

    public async Task UpdateAsync(Guid id, UpdateCategoryDto dto)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        if (category == null)
            return;

        category.UpdateName(dto.Name);
        _categoryRepository.Update(category);
    }

    public async Task DeleteAsync(Guid id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        if (category == null)
            return;

        _categoryRepository.Delete(category);
    }
}
