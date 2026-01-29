using Microsoft.AspNetCore.Mvc;
using MusmulogullariMarket.Application.DTOs.ProductImages;
using MusmulogullariMarket.Application.Interfaces.Services;

namespace MusmulogullariMarket.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductImagesController : ControllerBase
{
    private readonly IProductImageService _imageService;

    public ProductImagesController(IProductImageService imageService)
    {
        _imageService = imageService;
    }

    [HttpGet("product/{productId}")]
    public async Task<IActionResult> GetByProduct(Guid productId)
    {
        var images = await _imageService.GetByProductIdAsync(productId);
        return Ok(images);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateProductImageDto dto)
    {
        await _imageService.AddAsync(dto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _imageService.DeleteAsync(id);
        return Ok();
    }
}
