using Domain.Categories;
using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Products;

public sealed class Product : AggregateRoot
{
    public Product(ProductId id, string name, string description, decimal price, int stock, CategoryId categoryId, bool isActive)
    {
        Id = id;
        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        CategoryId = categoryId;
        IsActive = isActive;
    }

    private Product() {}

    public ProductId Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public int Stock { get; private set; } = 0;
    public CategoryId CategoryId { get; private set; }
    public bool IsActive { get; private set; }

    public static Product UpdateProduct(Guid id, string name, string description, decimal price, int stock, CategoryId categoryId, bool isActive)
    {
        return new Product(new ProductId(id), name, description, price, stock, categoryId, isActive);
    }

    public void DecreaseStock(int quantity)
    {
        if (quantity > Stock)
        {
            throw new InvalidOperationException("Insufficient stock for the requested quantity.");
        }

        Stock -= quantity;
    }

    public void IncreaseStock(int quantity)
    {
        Stock += quantity;
    }
}
