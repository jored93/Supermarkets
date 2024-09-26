namespace Application.Customers.Create;

public record CreateCustomerCommand(
    string Name,
    string LastName,
    string Email,
    string Identification,
    bool IsActive
    ) : IRequest<ErrorOr<Guid>>;