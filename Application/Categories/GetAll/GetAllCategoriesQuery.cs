using Categories.Common;

namespace Application.Categories.GetAll;

public record GetAllCategoriesQuery() : IRequest<ErrorOr<IReadOnlyList<CategoryResponse>>>;

