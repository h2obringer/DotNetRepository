using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WorkByrdLibrary.EntityFramework.Schema
{
    public class TimeZoneSchema : IEntityTypeConfiguration<Tables.TimeZone>
    {
        public void Configure(EntityTypeBuilder<Tables.TimeZone> builder)
        {
            builder.ToTable("TimeZone")
                .HasKey(p => p.ID);

            builder.Property(p=>p.ID)
                .HasColumnName("ID")
                .UseIdentityColumn();

            builder.Property(p => p.Abbreviation)
                .HasColumnName("sAbbreviation")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(p => p.Zone)
                .HasColumnName("sName")
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(p => p.UtcOffset)
                .HasColumnName("sUTCOffset")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(p => p.IsActive)
                .HasColumnName("bActive")
                .HasDefaultValue(false)
                .IsRequired();

            builder.Property(p => p.ChangedByUserID)
                .HasMaxLength(256)
                .HasDefaultValue("")
                .IsRequired();
        }
    }
}
