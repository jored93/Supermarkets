using Domain.Invoices;
using Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.ToTable("Invoices");

        builder.HasKey(i => i.Id);

        builder.Property(i => i.Id).HasConversion(
            invoiceId => invoiceId.Value,
            value => new InvoiceId(value));

        builder.Property(i => i.Date)
            .HasColumnType("datetime")
            .IsRequired();

        builder.Property(i => i.TotalAmount)
            .HasColumnType("decimal(18,2)");

        // Relación con Customer
        builder.HasOne<Customer>()
            .WithMany()
            .HasForeignKey(i => i.CustomerId);
    }
}
