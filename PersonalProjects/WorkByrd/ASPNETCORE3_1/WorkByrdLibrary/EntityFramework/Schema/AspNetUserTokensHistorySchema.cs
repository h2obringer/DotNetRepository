using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WorkByrdLibrary.EntityFramework.Tables;
using WorkByrdLibrary.Objects;

namespace WorkByrdLibrary.EntityFramework.Schema
{
    public class AspNetUserTokensHistorySchema : IEntityTypeConfiguration<AspNetUserTokensHistory>
    {
        public void Configure(EntityTypeBuilder<AspNetUserTokensHistory> builder)
        {
            builder.ToTable("AspNetUserTokensHistory")
                .HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("Id")
                .HasMaxLength(36)
                .IsRequired();

            builder.Property(p => p.UserID)
                .HasColumnName("UserId")
                .HasMaxLength(36)
                .IsRequired();

            builder.Property(p => p.LoginProvider)
                .HasColumnName("LoginProvider")
                .IsRequired();

            builder.Property(p => p.Name)
                .HasColumnName("Name");

            builder.Property(p => p.Value)
                .HasColumnName("Value");

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
