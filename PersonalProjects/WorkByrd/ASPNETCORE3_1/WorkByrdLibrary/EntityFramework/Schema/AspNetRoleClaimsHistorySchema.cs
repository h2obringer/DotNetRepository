using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WorkByrdLibrary.EntityFramework.Tables;
using WorkByrdLibrary.Objects;

namespace WorkByrdLibrary.EntityFramework.Schema
{
    public class AspNetRoleClaimsHistorySchema : IEntityTypeConfiguration<AspNetRoleClaimsHistory>
    {
        public void Configure(EntityTypeBuilder<AspNetRoleClaimsHistory> builder)
        {
            builder.ToTable("AspNetRoleClaimsHistory")
                .HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("Id")
                .HasMaxLength(36)
                .IsRequired();

            builder.Property(p => p.AspNetRoleClaims_ID)
                .HasColumnName("AspNetRoleClaims_Id")
                .IsRequired();

            builder.Property(p => p.RoleID)
                .HasColumnName("RoleId")
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
