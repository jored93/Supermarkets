namespace Application.Products.Create;

public record CreateProductCommand(
    string Name,
    string Description,
    decimal Price,
    int Stock,
    Guid CategoryId,
    bool IsActive
    ) : IRequest<ErrorOr<Guid>>;

