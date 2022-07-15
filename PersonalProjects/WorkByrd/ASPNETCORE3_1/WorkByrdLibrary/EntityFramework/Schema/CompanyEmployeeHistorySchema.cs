using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WorkByrdLibrary.EntityFramework.Tables;
using WorkByrdLibrary.Objects;

namespace WorkByrdLibrary.EntityFramework.Schema
{
    public class CompanyEmployeeHistorySchema : IEntityTypeConfiguration<CompanyEmployeeHistory>
    {
        public void Configure(EntityTypeBuilder<CompanyEmployeeHistory> builder)
        {
            builder.ToTable("CompanyEmployeeHistory")
                .HasKey(p => p.ID);

            builder.Property(p => p.ID)
                .HasColumnName("ID")
                .HasMaxLength(36)
                .IsRequired();

            builder.Property(p => p.CompanyEmployee_ID)
                .HasColumnName("CompanyEmployee_ID")
                .HasMaxLength(36);

            builder.Property(p => p.CompanyID)
                .HasColumnName("fkCompanyID")
                .HasMaxLength(36);

            builder.Property(p => p.UserID)
                .HasColumnName("fkAspNetUsersID")
                .HasMaxLength(36);

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
