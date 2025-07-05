using Domain.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Infrastructure.Common.Extensions;
using Microsoft.Extensions.Configuration;


namespace Infrastructure.Persistence.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _context;
    private readonly string _spGetCategories;

    public CategoryRepository(ApplicationDbContext context, IConfiguration configuration)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _spGetCategories = configuration.GetSection("StoredProcedures:SpGetCategories").Value
                            ?? throw new ArgumentNullException(nameof(_spGetCategories));
    }

    public void Add(Category category) => _context.Categories.Add(category);
    public void Delete(Category category) => _context.Categories.Remove(category);
    public void Update(Category category) => _context.Categories.Update(category);
    public async Task<bool> ExistsAsync(CategoryId id) => await _context.Categories.AnyAsync(category => category.Id == id);
    public async Task<Category?> GetByIdAsync(CategoryId id) => await _context.Categories.SingleOrDefaultAsync(c => c.Id == id);
    /* public async Task<List<Category>> GetAll() => await _context.Categories.ToListAsync(); */

    public async Task<List<Category>> GetAll(Guid? id = null, string? name = null)
    {
        var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Id", id ?? (object)DBNull.Value),
                new SqlParameter("@Name", name ?? (object)DBNull.Value)
            };

        string parametrosSql = parametros.ObtenerCadenaParamSQL();

        var resultado = await _context.Categories
            .FromSqlRaw($"EXEC {_spGetCategories} {parametrosSql}", parametros.ToArray())
            .ToListAsync();

        return resultado;
    }
}

