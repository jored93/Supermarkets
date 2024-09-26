namespace Application.Customers.Update;

public record UpdateCustomerCommand(
    Guid Id,
    string Name,
    string LastName,
    string Email,
    string Identification,
    bool IsActive) : IRequest<ErrorOr<Unit>>;