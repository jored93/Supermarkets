using Domain.Invoices;
using Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class InvoiceDetailConfiguration : IEntityTypeConfiguration<InvoiceDetail>
{
    public void Configure(EntityTypeBuilder<InvoiceDetail> builder)
    {
        builder.ToTable("InvoiceDetails");

        builder.HasKey(id => id.Id);

        builder.Property(id => id.Id).HasConversion(
            invoiceDetailId => invoiceDetailId.Value,
            value => new InvoiceDetailId(value));

        builder.Property(id => id.Quantity)
            .IsRequired();

        builder.Property(id => id.UnitPrice)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(id => id.TotalPrice)
            .HasColumnType("decimal(18,2)");

        // Relación con Invoice
        builder.HasOne<Invoice>()
            .WithMany(i => i.InvoiceDetails)
            .HasForeignKey(id => id.InvoiceId);

        // Relación con Product
        builder.HasOne<Product>()
            .WithMany()
            .HasForeignKey(id => id.ProductId);
    }
}

