namespace Application.Categories.Create;

public record CreateCategoryCommand(
    string Name,
    string Description
    ) : IRequest<ErrorOr<Guid>>;
