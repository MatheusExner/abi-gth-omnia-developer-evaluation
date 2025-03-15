using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ToTable("Sales");

        builder.HasKey(s => s.Id);
        builder.HasIndex(s => s.SaleNumber);

        builder.Property(s => s.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(s => s.SaleNumber).IsRequired();
        builder.Property(s => s.SaleDate).IsRequired();
        builder.Property(s => s.IsCancelled).IsRequired();

        builder.HasOne(s => s.Customer).WithMany().HasForeignKey("CustomerId").OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(s => s.Branch).WithMany().HasForeignKey("BranchId").OnDelete(DeleteBehavior.Restrict);

    }
}
