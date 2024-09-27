using Domain.Customers;
using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Invoices;

public sealed class Invoice : AggregateRoot
{
    public Invoice(InvoiceId id, CustomerId customerId, DateTime date, decimal totalAmount)
    {
        Id = id;
        CustomerId = customerId;
        Date = date;
        TotalAmount = totalAmount;
        InvoiceDetails = new List<InvoiceDetail>();
    }

    private Invoice() {}

    public InvoiceId Id { get; private set; }
    public CustomerId CustomerId { get; private set; }
    public DateTime Date { get; private set; }
    public decimal TotalAmount { get; private set; }

    // Relación con los detalles de la factura (productos vendidos)
    public List<InvoiceDetail> InvoiceDetails { get; private set; }

    public void AddInvoiceDetail(InvoiceDetail detail)
    {
        InvoiceDetails.Add(detail);
    }
}
