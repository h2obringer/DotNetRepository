using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WorkByrdLibrary.EntityFramework.Tables;
using WorkByrdLibrary.Objects;

namespace WorkByrdLibrary.EntityFramework.Schema
{
    public class CompanyHistorySchema : IEntityTypeConfiguration<CompanyHistory>
    {
        public void Configure(EntityTypeBuilder<CompanyHistory> builder)
        {
            builder.ToTable("CompanyHistory")
                .HasKey(p => p.ID);

            builder.Property(p => p.ID)
                .HasColumnName("ID")
                .HasMaxLength(36)
                .IsRequired();

            builder.Property(p => p.CompanyID)
                .HasColumnName("Company_ID")
                .HasMaxLength(36)
                .IsRequired();

            builder.Property(p => p.Name)
                .HasColumnName("sName")
                .HasMaxLength(256);

            builder.Property(p => p.PhoneNumber)
                .HasColumnName("sPhone")
                .HasMaxLength(100);

            builder.Property(p => p.Email)
                .HasColumnName("sEmail")
                .HasMaxLength(256);

            builder.Property(p => p.IsEmailConfirmed)
                .HasColumnName("bEmailConfirmed");

            builder.Property(p => p.Address1)
                .HasColumnName("sAddressLine1")
                .HasMaxLength(256);

            builder.Property(p => p.Address2)
                .HasColumnName("sAddressLine2")
                .HasMaxLength(256);

            builder.Property(p => p.Address3)
                .HasColumnName("sAddressLine3")
                .HasMaxLength(256);

            builder.Property(p => p.City)
                .HasColumnName("sCity")
                .HasMaxLength(256);

            builder.Property(p => p.StateProvinceID)
                .HasColumnName("fkStateProvinceID");

            builder.Property(p => p.ZipCode)
                .HasColumnName("sZipCode")
                .HasMaxLength(25);

            builder.Property(p => p.URL)
                .HasColumnName("sURL")
                .HasMaxLength(256);

            builder.Property(p => p.BusinessHours)
                .HasColumnName("sBusinessHours")
                .HasMaxLength(1000);

            builder.Property(p => p.TimeZoneID)
                .HasColumnName("fkTimeZoneID");

            builder.Property(p => p.StripeCustomerID)
                .HasColumnName("sStripeCustomerID");

            builder.Property(p => p.StripeCreateCustomerDetails)
                .HasColumnName("sStripeCreateCustomerDetails");

            builder.Property(p => p.SubscriptionType)
                .HasColumnName("sSubscriptionType")
                .HasMaxLength(256);

            builder.Property(p => p.SubscriptionExpirationDateUTC)
                .HasColumnName("dtSubscriptionExpirationUTC");

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
