﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Northwind.Demo.Entity.Models;

namespace Northwind.Demo.Entity.ModelConfigs
{
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> entity)
        {

            entity.HasKey(e => e.EmployeeId).HasName("pk_employees");

            entity.ToTable("employees");

            entity.Property(e => e.EmployeeId)
                .ValueGeneratedNever()
                .HasColumnName("employee_id");
            entity.Property(e => e.Address)
                .HasMaxLength(60)
                .HasColumnName("address");
            entity.Property(e => e.BirthDate).HasColumnName("birth_date");
            entity.Property(e => e.City)
                .HasMaxLength(15)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(15)
                .HasColumnName("country");
            entity.Property(e => e.Extension)
                .HasMaxLength(4)
                .HasColumnName("extension");
            entity.Property(e => e.FirstName)
                .HasMaxLength(10)
                .HasColumnName("first_name")
                .IsRequired();
            entity.Property(e => e.HireDate).HasColumnName("hire_date");
            entity.Property(e => e.HomePhone)
                .HasMaxLength(24)
                .HasColumnName("home_phone");
            entity.Property(e => e.LastName)
                .HasMaxLength(20)
                .HasColumnName("last_name")
                .IsRequired();
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.Photo).HasColumnName("photo");
            entity.Property(e => e.PhotoPath)
                .HasMaxLength(255)
                .HasColumnName("photo_path");
            entity.Property(e => e.PostalCode)
                .HasMaxLength(10)
                .HasColumnName("postal_code");
            entity.Property(e => e.Region)
                .HasMaxLength(15)
                .HasColumnName("region");
            entity.Property(e => e.ReportsTo).HasColumnName("reports_to");
            entity.Property(e => e.Title)
                .HasMaxLength(30)
                .HasColumnName("title");
            entity.Property(e => e.TitleOfCourtesy)
                .HasMaxLength(25)
                .HasColumnName("title_of_courtesy");

            entity.HasOne(d => d.ReportsToNavigation).WithMany(p => p.InverseReportsToNavigation)
                .HasForeignKey(d => d.ReportsTo)
                .HasConstraintName("fk_employees_employees");

            //entity.HasMany(d => d.Territories).WithMany(p => p.Employees)
            //    .UsingEntity<Dictionary<string, object>>(
            //        "EmployeeTerritory",
            //        r => r.HasOne<Territory>().WithMany()
            //            .HasForeignKey("TerritoryId")
            //            .OnDelete(DeleteBehavior.ClientSetNull)
            //            .HasConstraintName("fk_employee_territories_territories"),
            //        l => l.HasOne<Employee>().WithMany()
            //            .HasForeignKey("EmployeeId")
            //            .OnDelete(DeleteBehavior.ClientSetNull)
            //            .HasConstraintName("fk_employee_territories_employees"),
            //        j =>
            //        {
            //            j.HasKey("EmployeeId", "TerritoryId").HasName("pk_employee_territories");
            //            j.ToTable("employee_territories");
            //            j.IndexerProperty<short>("EmployeeId").HasColumnName("employee_id");
            //            j.IndexerProperty<string>("TerritoryId")
            //                .HasMaxLength(20)
            //                .HasColumnName("territory_id");
            //        });

        }
    }
}
