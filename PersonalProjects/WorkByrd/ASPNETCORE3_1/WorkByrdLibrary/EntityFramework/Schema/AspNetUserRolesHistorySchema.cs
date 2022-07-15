using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WorkByrdLibrary.EntityFramework.Tables;
using WorkByrdLibrary.Objects;

namespace WorkByrdLibrary.EntityFramework.Schema
{
    public class AspNetUserRolesHistorySchema : IEntityTypeConfiguration<AspNetUserRolesHistory>
    {
        public void Configure(EntityTypeBuilder<AspNetUserRolesHistory> builder)
        {
            builder.ToTable("AspNetUserRolesHistory")
                .HasKey(p => p.ID);

            builder.Property(p => p.ID)
                .HasColumnName("Id")
                .HasMaxLength(36)
                .IsRequired();

            builder.Property(p => p.AspNetUserRoles_UserID)
                .HasColumnName("AspNetUserRoles_UserId")
                .HasMaxLength(36)
                .IsRequired();

            builder.Property(p => p.AspNetUserRoles_RoleID)
                .HasColumnName("AspNetUserRoles_RoleId")
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
