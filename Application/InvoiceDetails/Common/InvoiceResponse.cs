namespace Invoices.Common;

public record InvoiceDetailResponse(
    Guid Id,
    Guid ProductId,
    int Quantity,
    decimal UnitPrice
);
