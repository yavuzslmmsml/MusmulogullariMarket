namespace MusmulogullariMarket.Application.DTOs.ProductImages;

public class CreateProductImageDto
{
    public Guid ProductId { get; set; }
    public string ImagePath { get; set; } = string.Empty;
}
