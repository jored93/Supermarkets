using Categories.Common;

namespace Application.Categories.GetById;

public record GetCategoryByIdQuery(Guid Id) : IRequest<ErrorOr<CategoryResponse>>;

