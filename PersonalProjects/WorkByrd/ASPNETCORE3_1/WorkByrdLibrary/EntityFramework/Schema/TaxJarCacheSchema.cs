using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WorkByrdLibrary.EntityFramework.Tables;

namespace WorkByrdLibrary.EntityFramework.Schema
{
    public class TaxJarCacheSchema : IEntityTypeConfiguration<TaxJarCache>
    {
        public void Configure(EntityTypeBuilder<TaxJarCache> builder)
        {
            builder.ToTable("TaxJarCache")
                .HasKey(p => p.ID);

            builder.Property(p => p.Company_ID)
                .HasColumnName("fkCompanyID")
                .HasMaxLength(36);

            builder.Property(p => p.TaxResponseAttributes)
                .HasColumnName("sTaxResponseAttributes");

            builder.Property(p => p.LastUpdatedDateUTC)
                .HasColumnName("dtLastUpdatedDateUTC");
        }
    }
}
