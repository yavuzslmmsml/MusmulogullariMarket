using MusmulogullariMarket.Domain.Common;

namespace MusmulogullariMarket.Domain.Entities;

public class ProductImage : BaseEntity
{
    public Guid ProductId { get; private set; }
    public Product Product { get; private set; }

    public string ImagePath { get; private set; }      // Resmin sunucudaki yolu
    public bool IsMain { get; private set; }          // Ana görsel mi?

    private ProductImage() { } // EF Core için

    public ProductImage(Guid productId, string imagePath, bool isMain = false)
    {
        if (string.IsNullOrWhiteSpace(imagePath))
            throw new ArgumentException("Image path cannot be empty");

        ProductId = productId;
        ImagePath = imagePath;
        IsMain = isMain;
    }

    public void SetAsMain()
    {
        IsMain = true;
    }

    public void RemoveMain()
    {
        IsMain = false;
    }
}