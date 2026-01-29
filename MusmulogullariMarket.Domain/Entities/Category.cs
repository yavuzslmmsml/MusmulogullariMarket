using MusmulogullariMarket.Domain.Common;

namespace MusmulogullariMarket.Domain.Entities;

public class Category : BaseEntity
{
    public string Name { get; private set; }

    private Category() { }

    public Category(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Category name cannot be empty");

        Name = name;
    }

    public void UpdateName(string name)
    {
        Name = name;
    }
}
