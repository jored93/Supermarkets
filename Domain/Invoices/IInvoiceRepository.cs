namespace Domain.Invoices;

public interface IInvoiceRepository
{
    Task<List<Invoice>> GetAll();
    Task<Invoice?> GetByIdAsync(InvoiceId id);
    Task<bool> ExistsAsync(InvoiceId id);
    void Add(Invoice invoice);
    void Update(Invoice invoice);
    void Delete(Invoice invoice);
}
