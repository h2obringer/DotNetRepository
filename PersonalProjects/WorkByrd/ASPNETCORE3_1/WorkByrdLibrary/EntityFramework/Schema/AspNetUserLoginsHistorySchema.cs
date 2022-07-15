using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WorkByrdLibrary.EntityFramework.Tables;
using WorkByrdLibrary.Objects;

namespace WorkByrdLibrary.EntityFramework.Schema
{
    public class AspNetUserLoginsHistorySchema : IEntityTypeConfiguration<AspNetUserLoginsHistory>
    {
        public void Configure(EntityTypeBuilder<AspNetUserLoginsHistory> builder)
        {
            builder.ToTable("AspNetUserLoginsHistory")
                .HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("ID")
                .HasMaxLength(36)
                .IsRequired();

            builder.Property(p => p.LoginProvider)
                .HasColumnName("LoginProvider")
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(p => p.ProviderKey)
                .HasColumnName("ProviderKey")
                .HasMaxLength(256);

            builder.Property(p => p.ProviderDisplayName)
                .HasColumnName("ProviderDisplayName")
                .HasMaxLength(256);

            builder.Property(p => p.UserID)
                .HasColumnName("UserId")
                .HasMaxLength(36)
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
