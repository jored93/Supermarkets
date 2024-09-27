namespace Domain.Categories;

public interface ICategoryRepository
{
    Task<List<Category>> GetAll();
    Task<Category?> GetByIdAsync(CategoryId id);
    Task<bool> ExistsAsync(CategoryId id);
    void Add(Category category);
    void Update(Category category);
    void Delete(Category category);
}
