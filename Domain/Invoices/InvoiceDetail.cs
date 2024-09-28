using Domain.Products;
using Domain.Primitives;

namespace Domain.Invoices;

public sealed class InvoiceDetail : AggregateRoot
{
    public InvoiceDetail(InvoiceDetailId id, InvoiceId invoiceId, ProductId productId, int quantity, decimal unitPrice)
    {
        Id = id;
        InvoiceId = invoiceId;
        ProductId = productId;
        Quantity = quantity;
        UnitPrice = unitPrice;
        TotalPrice = quantity * unitPrice;
    }

    private InvoiceDetail() {}

    public InvoiceDetailId Id { get; private set; }
    public InvoiceId InvoiceId { get; private set; }
    public ProductId ProductId { get; private set; }
    public int Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }
    public decimal TotalPrice { get; private set; }

    public void UpdateStock(Product product)
    {
        if (product.Stock == 0)
        {
            throw new InvalidOperationException("Cannot add product to invoice. Stock is zero.");
        }

        product.DecreaseStock(Quantity);
    }
}
