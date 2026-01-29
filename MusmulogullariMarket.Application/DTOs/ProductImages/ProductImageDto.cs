namespace MusmulogullariMarket.Application.DTOs.ProductImages;

public class ProductImageDto
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public string ImagePath { get; set; } = string.Empty;
}
