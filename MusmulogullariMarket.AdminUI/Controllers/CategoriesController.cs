using Microsoft.AspNetCore.Mvc;
using MusmulogullariMarket.AdminUI.ViewModels.Categories;
using MusmulogullariMarket.AdminUI.Services.Categories;
using System.Net.Http.Json;
namespace MusmulogullariMarket.AdminUI.Controllers
{
    public class CategoriesController : Controller
{
    private readonly ICategoryApiService _categoryApiService;

    public CategoriesController(ICategoryApiService categoryApiService)
    {
        _categoryApiService = categoryApiService;
    }

    public async Task<IActionResult> Index()
    {
        var categories = await _categoryApiService.GetAllAsync();
        var vm = new CategoriesPageViewModel
        {
            Categories = categories
        };
        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateCategoryViewModel model)
    {
        if (!ModelState.IsValid)
            {
            ModelState.AddModelError("", "ModelState invalid");    
            return RedirectToAction(nameof(Index));
            }

        await _categoryApiService.CreateAsync(model);

        return RedirectToAction(nameof(Index));
    }

    // UPDATE
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(UpdateCategoryViewModel model)
    {
        if (!ModelState.IsValid)
            return RedirectToAction(nameof(Index));

        await _categoryApiService.UpdateAsync(model);

        return RedirectToAction(nameof(Index));
    }

    // DELETE
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _categoryApiService.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }

    
}
}