﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Northwind.Demo.Entity.Models;

namespace Northwind.Demo.Entity.ModelConfigs
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("products");

            builder.HasKey(e => e.ProductId).HasName("pk_products");

            builder.Property(e => e.ProductId)
                .ValueGeneratedNever()
                .HasColumnName("product_id");

            builder.Property(e => e.CategoryId).HasColumnName("category_id");

            builder.Property(e => e.Discontinued)
                .HasColumnName("discontinued")
                .IsRequired();

            builder.Property(e => e.ProductName)
                .HasMaxLength(40)
                .HasColumnName("product_name")
                .IsRequired();

            builder.Property(e => e.QuantityPerUnit)
                .HasMaxLength(20)
                .HasColumnName("quantity_per_unit");

            builder.Property(e => e.ReorderLevel).HasColumnName("reorder_level");

            builder.Property(e => e.SupplierId).HasColumnName("supplier_id");

            builder.Property(e => e.UnitPrice).HasColumnName("unit_price");

            builder.Property(e => e.UnitsInStock).HasColumnName("units_in_stock");

            builder.Property(e => e.UnitsOnOrder).HasColumnName("units_on_order");

            builder.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("fk_products_categories");

            builder.HasOne(d => d.Supplier).WithMany(p => p.Products)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("fk_products_suppliers");
        }
    }
}
