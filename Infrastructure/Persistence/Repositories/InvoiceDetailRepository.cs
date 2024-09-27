using Domain.Invoices;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class InvoiceDetailRepository : IInvoiceDetailRepository
{
    private readonly ApplicationDbContext _context;

    public InvoiceDetailRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public void Add(InvoiceDetail invoiceDetail) => _context.InvoiceDetails.Add(invoiceDetail);
    public void Delete(InvoiceDetail invoiceDetail) => _context.InvoiceDetails.Remove(invoiceDetail);
    public void Update(InvoiceDetail invoiceDetail) => _context.InvoiceDetails.Update(invoiceDetail);
    public async Task<InvoiceDetail?> GetByIdAsync(InvoiceDetailId id) => await _context.InvoiceDetails.SingleOrDefaultAsync(detail => detail.Id == id);
    public async Task<List<InvoiceDetail>> GetByInvoiceIdAsync(InvoiceId invoiceId) => await _context.InvoiceDetails
        .Where(id => id.InvoiceId == invoiceId)
        .ToListAsync();
}

