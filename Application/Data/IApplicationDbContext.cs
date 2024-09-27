using Domain.Categories;
using Domain.Customers;
using Domain.Invoices;
using Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace Application.Data;

public interface IApplicationDbContext
{
    DbSet<Customer> Customers { get; set; }
    DbSet<Product> Products { get; set; }
    DbSet<Category> Categories { get; set; }
    DbSet<Invoice> Invoices { get; set; }
    DbSet<InvoiceDetail> InvoiceDetails { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}