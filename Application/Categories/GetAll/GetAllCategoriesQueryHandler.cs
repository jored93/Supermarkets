using Categories.Common;
using Domain.Categories;

namespace Application.Categories.GetAll;

internal sealed class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, ErrorOr<IReadOnlyList<CategoryResponse>>>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetAllCategoriesQueryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
    }

    public async Task<ErrorOr<IReadOnlyList<CategoryResponse>>> Handle(GetAllCategoriesQuery query, CancellationToken cancellationToken)
    {
        IReadOnlyList<Category> categories = await _categoryRepository.GetAll();

        return categories.Select(category => new CategoryResponse(
                category.Id.Value,
                category.Name,
                category.Description
            )).ToList();
    }
}

