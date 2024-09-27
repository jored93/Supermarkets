namespace Application.Categories.Delete;

public record DeleteCategoryCommand(Guid Id) : IRequest<ErrorOr<Unit>>;

