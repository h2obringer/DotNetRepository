using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Text;
using WorkByrdLibrary.EntityFramework.Tables;
using WorkByrdLibrary.Objects;

namespace WorkByrdLibrary.EntityFramework.Schema
{
    public class StateProvinceHistorySchema : IEntityTypeConfiguration<StateProvinceHistory>
    {
        public void Configure(EntityTypeBuilder<StateProvinceHistory> builder)
        {
            builder.ToTable("StateProvinceHistory")
                .HasKey(p => p.ID);

            builder.Property(p => p.ID)
                .HasColumnName("ID")
                .HasMaxLength(36)
                .IsRequired();

            builder.Property(p => p.StateProvince_ID)
                .HasColumnName("StateProvince_ID")
                .IsRequired();

            builder.Property(p => p.Name)
                .HasColumnName("sName");

            builder.Property(p => p.Abbreviation)
                .HasColumnName("sAbbreviation")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(p => p.CountryID)
                .HasColumnName("fkCountryID")
                .HasMaxLength(10);

            builder.Property(p => p.HasTaxNexus)
                .HasColumnName("bHasTaxNexus")
                .IsRequired();

            builder.Property(p => p.LastModifiedByUserID)
                .HasColumnName("LastModifiedByUserID")
                .HasMaxLength(36);

            builder.Property(p => p.LastModifiedDateTimeUTC)
                .HasColumnName("LastModifiedDateUTC");

            builder.Property(p => p.HistoryAction)
                .HasColumnName("iOperation")
                .HasConversion(new EnumToNumberConverter<HistoryAuditAction, int>()); //allow property mapping of database value to the HistoryAuditAction enum value and vice versa
        }
    }
}
