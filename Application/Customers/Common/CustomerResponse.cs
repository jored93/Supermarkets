namespace Customers.Common;

public record CustomerResponse(
Guid Id,
string FullName,
string Email,
string Identification,
bool IsActive);
