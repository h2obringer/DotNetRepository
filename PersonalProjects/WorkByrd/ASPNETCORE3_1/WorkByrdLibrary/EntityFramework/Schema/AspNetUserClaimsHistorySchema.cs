using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WorkByrdLibrary.EntityFramework.Tables;
using WorkByrdLibrary.Objects;

namespace WorkByrdLibrary.EntityFramework.Schema
{
    public class AspNetUserClaimsHistorySchema : IEntityTypeConfiguration<AspNetUserClaimsHistory>
    {
        public void Configure(EntityTypeBuilder<AspNetUserClaimsHistory> builder)
        {
            builder.ToTable("AspNetUserClaimsHistory")
                .HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("Id")
                .HasMaxLength(36)
                .IsRequired();

            builder.Property(p => p.AspNetUserClaims_ID)
                .HasColumnName("AspNetUserClaims_Id")
                .IsRequired();

            builder.Property(p => p.UserID)
                .HasColumnName("UserId")
                .HasMaxLength(36)
                .IsRequired();

            builder.Property(p => p.ClaimType)
                .HasColumnName("ClaimType");

            builder.Property(p => p.ClaimValue)
                .HasColumnName("ClaimValue");

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
