namespace Application.InvoiceDetails.Create;

public record CreateInvoiceDetailCommand(
    Guid ProductId,
    int Quantity,
    decimal UnitPrice
    );
