using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WorkByrdLibrary.EntityFramework.Tables;
using WorkByrdLibrary.Objects;

namespace WorkByrdLibrary.EntityFramework.Schema
{
    public class CountryHistorySchema : IEntityTypeConfiguration<CountryHistory>
    {
        public void Configure(EntityTypeBuilder<CountryHistory> builder)
        {
            builder.ToTable("CountryHistory")
                .HasKey(p => p.ID);

            builder.Property(p => p.ID)
                .HasColumnName("ID")
                .HasMaxLength(36)
                .IsRequired();

            builder.Property(p => p.Country_ID)
                .HasColumnName("Country_ID")
                .IsRequired();

            builder.Property(p => p.Name)
                .HasColumnName("sName")
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(p => p.Abbreviation)
                .HasColumnName("sAbbreviation")
                .HasMaxLength(5);

            builder.Property(p => p.ContinentID)
                .HasColumnName("fkContinentID");

            builder.Property(p => p.IsActive)
                .HasColumnName("bActive");

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
