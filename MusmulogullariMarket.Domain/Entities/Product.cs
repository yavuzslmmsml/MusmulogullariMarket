using MusmulogullariMarket.Domain.Common;

namespace MusmulogullariMarket.Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public int Stock { get; private set; }

    public Guid CategoryId { get; private set; }
    public Category Category { get; private set; }

    private Product() { } // EF Core

    public Product(
        string name,
        string description,
        decimal price,
        int stock,
        Guid categoryId)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Product name cannot be empty");

        if (price <= 0)
            throw new ArgumentException("Price must be greater than zero");

        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        CategoryId = categoryId;
    }

    public void UpdatePrice(decimal newPrice)
    {
        if (newPrice <= 0)
            throw new ArgumentException("Price must be greater than zero");

        Price = newPrice;
    }

    public void DecreaseStock(int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero");

        if (Stock < quantity)
            throw new InvalidOperationException("Not enough stock");

        Stock -= quantity;
    }
}
