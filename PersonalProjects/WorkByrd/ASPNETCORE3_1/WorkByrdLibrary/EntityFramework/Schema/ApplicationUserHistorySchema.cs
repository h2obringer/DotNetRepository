using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WorkByrdLibrary.EntityFramework.Tables;
using WorkByrdLibrary.Objects;

namespace WorkByrdLibrary.EntityFramework.Schema
{
    public class ApplicationUserHistorySchema : IEntityTypeConfiguration<ApplicationUserHistory>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserHistory> builder)
        {
            builder.ToTable("AspNetUsersHistory")
                .HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("Id")
                .HasMaxLength(36)
                .IsRequired();

            builder.Property(p => p.AspNetUsers_ID)
                .HasColumnName("AspNetUsers_Id")
                .HasMaxLength(36)
                .IsRequired();

            builder.Property(p => p.LastName)
                .HasColumnName("LastName")
                .HasMaxLength(256);

            builder.Property(p => p.UserName)
                .HasColumnName("UserName")
                .HasMaxLength(256);

            builder.Property(p => p.NormalizedUserName)
                .HasColumnName("NormalizedUserName")
                .HasMaxLength(256);

            builder.Property(p => p.Email)
                .HasColumnName("Email")
                .HasMaxLength(256);

            builder.Property(p => p.NormalizedEmail)
                .HasColumnName("NormalizedEmail")
                .HasMaxLength(256);

            builder.Property(p => p.EmailConfirmed)
                .HasColumnName("EmailConfirmed");

            builder.Property(p => p.PasswordHash)
                .HasColumnName("PasswordHash");

            builder.Property(p => p.SecurityStamp)
                .HasColumnName("SecurityStamp");

            builder.Property(p => p.ConcurrencyStamp)
                .HasColumnName("ConcurrencyStamp");

            builder.Property(p => p.PhoneNumber)
                .HasColumnName("PhoneNumber")
                .HasMaxLength(100);

            builder.Property(p => p.PhoneNumberConfirmed)
                .HasColumnName("PhoneNumberConfirmed");

            builder.Property(p => p.TwoFactorEnabled)
                .HasColumnName("TwoFactorEnabled");

            builder.Property(p => p.LockoutEnd)
                .HasColumnName("LockoutEnd");

            builder.Property(p => p.LockoutEnabled)
                .HasColumnName("LockoutEnabled");

            builder.Property(p => p.AccessFailedCount)
                .HasColumnName("AccessFailedCount");

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
