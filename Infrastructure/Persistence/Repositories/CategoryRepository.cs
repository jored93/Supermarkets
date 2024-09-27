using Domain.Categories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _context;

    public CategoryRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public void Add(Category category) => _context.Categories.Add(category);
    public void Delete(Category category) => _context.Categories.Remove(category);
    public void Update(Category category) => _context.Categories.Update(category);
    public async Task<bool> ExistsAsync(CategoryId id) => await _context.Categories.AnyAsync(category => category.Id == id);
    public async Task<Category?> GetByIdAsync(CategoryId id) => await _context.Categories.SingleOrDefaultAsync(c => c.Id == id);
    public async Task<List<Category>> GetAll() => await _context.Categories.ToListAsync();
}

