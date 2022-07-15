using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WorkByrdLibrary.EntityFramework.Tables;
using WorkByrdLibrary.Objects;

namespace WorkByrdLibrary.EntityFramework.Schema
{
    public class TimeZoneHistorySchema : IEntityTypeConfiguration<TimeZoneHistory>
    {
        public void Configure(EntityTypeBuilder<TimeZoneHistory> builder)
        {
            builder.ToTable("TimeZoneHistory")
                .HasKey(p => p.ID);

            builder.Property(p => p.ID)
                .HasColumnName("ID")
                .HasMaxLength(36)
                .IsRequired();

            builder.Property(p => p.TimeZone_ID)
                .HasColumnName("TimeZone_ID")
                .IsRequired();

            builder.Property(p => p.Abbreviation)
                .HasColumnName("sAbbreviation")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(p => p.Zone)
                .HasColumnName("sName");

            builder.Property(p => p.UtcOffset)
                .HasColumnName("sUTCOffset")
                .HasMaxLength(10);

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
