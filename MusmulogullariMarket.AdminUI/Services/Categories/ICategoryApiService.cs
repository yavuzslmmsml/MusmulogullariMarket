using MusmulogullariMarket.AdminUI.ViewModels.Categories;

namespace MusmulogullariMarket.AdminUI.Services.Categories;

public interface ICategoryApiService
{
    Task<List<CategoryViewModel>> GetAllAsync();
    Task CreateAsync(CreateCategoryViewModel model);

    Task UpdateAsync(UpdateCategoryViewModel model);

    Task DeleteAsync(Guid id);
}
