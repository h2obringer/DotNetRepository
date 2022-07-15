using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WorkByrdLibrary.EntityFramework.Tables;
using WorkByrdLibrary.Objects;

namespace WorkByrdLibrary.EntityFramework.Schema
{
    public class AspNetRolesHistorySchema : IEntityTypeConfiguration<AspNetRolesHistory>
    {
        public void Configure(EntityTypeBuilder<AspNetRolesHistory> builder)
        {
            builder.ToTable("AspNetRolesHistory")
                .HasKey(p => p.Id);
            
            builder.Property(p => p.Id)
                .HasColumnName("Id")
                .HasMaxLength(36)
                .IsRequired();

            builder.Property(p => p.AspNetRoles_ID)
                .HasColumnName("AspNetRoles_Id")
                .HasMaxLength(36)
                .IsRequired();

            builder.Property(p => p.Name)
                .HasColumnName("Name")
                .HasMaxLength(256);

            builder.Property(p => p.NormalizedName)
                .HasColumnName("NormalizedName")
                .HasMaxLength(256);

            builder.Property(p => p.ConcurrencyStamp)
                .HasColumnName("ConcurrencyStamp");

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
