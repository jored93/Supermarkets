namespace Domain.Invoices;

public interface IInvoiceDetailRepository
{
    Task<List<InvoiceDetail>> GetByInvoiceIdAsync(InvoiceId invoiceId);
    Task<InvoiceDetail?> GetByIdAsync(InvoiceDetailId id);
    void Add(InvoiceDetail invoiceDetail);
    void Update(InvoiceDetail invoiceDetail);
    void Delete(InvoiceDetail invoiceDetail);
}
