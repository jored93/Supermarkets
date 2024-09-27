using Categories.Common;
using Domain.Categories;

namespace Application.Categories.GetById;

internal sealed class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, ErrorOr<CategoryResponse>>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
    }

    public async Task<ErrorOr<CategoryResponse>> Handle(GetCategoryByIdQuery query, CancellationToken cancellationToken)
    {
        if (await _categoryRepository.GetByIdAsync(new CategoryId(query.Id)) is not Category category)
        {
            return Error.NotFound("Category.NotFound", "The category with the provided Id was not found.");
        }

        return new CategoryResponse(
            category.Id.Value,
            category.Name,
            category.Description);
    }
}

