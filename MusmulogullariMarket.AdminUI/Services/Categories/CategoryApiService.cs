using System.Net.Http.Json;
using MusmulogullariMarket.AdminUI.ViewModels.Categories;

namespace MusmulogullariMarket.AdminUI.Services.Categories;

public class CategoryApiService : ICategoryApiService
{
    private readonly HttpClient _client;

    public CategoryApiService(IHttpClientFactory factory)
    {
        _client = factory.CreateClient("MarketApi");
    }

    public async Task<List<CategoryViewModel>> GetAllAsync()
    {
        return await _client
            .GetFromJsonAsync<List<CategoryViewModel>>("categories")
            ?? new();
    }

    public async Task CreateAsync(CreateCategoryViewModel model)
    {
        await _client.PostAsJsonAsync("categories", model);
    }

    public async Task UpdateAsync(UpdateCategoryViewModel model)
    {
        await _client.PutAsJsonAsync($"categories/{model.Id}", model);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _client.DeleteAsync($"categories/{id}");
    }
}
