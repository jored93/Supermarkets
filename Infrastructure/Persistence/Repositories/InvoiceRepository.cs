using Domain.Invoices;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class InvoiceRepository : IInvoiceRepository
{
    private readonly ApplicationDbContext _context;

    public InvoiceRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public void Add(Invoice invoice) => _context.Invoices.Add(invoice);
    public void Delete(Invoice invoice) => _context.Invoices.Remove(invoice);
    public void Update(Invoice invoice) => _context.Invoices.Update(invoice);
    public async Task<bool> ExistsAsync(InvoiceId id) => await _context.Invoices.AnyAsync(invoice => invoice.Id == id);
    public async Task<Invoice?> GetByIdAsync(InvoiceId id) => await _context.Invoices
        .Include(i => i.InvoiceDetails)
        .SingleOrDefaultAsync(i => i.Id == id);
    public async Task<List<Invoice>> GetAll() => await _context.Invoices
        .Include(i => i.InvoiceDetails)
        .ToListAsync();
}

