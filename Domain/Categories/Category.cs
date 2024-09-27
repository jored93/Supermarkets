using Domain.Primitives;

namespace Domain.Categories;

public sealed class Category : AggregateRoot
{
    public Category(CategoryId id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }

    private Category() {}

    public CategoryId Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }

    public static Category UpdateCategory(Guid id, string name, string description)
    {
        return new Category(new CategoryId(id), name, description);
    }
}
