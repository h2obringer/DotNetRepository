using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkByrdLibrary.EntityFramework.Tables;

namespace WorkByrdLibrary.EntityFramework.Schema
{
    public class CompanySchema : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Company")
                .HasKey(p => p.ID);

            builder.Property(p => p.ID)
                .HasColumnName("ID")
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(p => p.Name)
                .HasColumnName("sName")
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(p => p.PhoneNumber)
                .HasColumnName("sPhone")
                .HasMaxLength(100);

            builder.Property(p => p.Email)
                .HasColumnName("sEmail")
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(p => p.IsEmailConfirmed)
                .HasColumnName("bEmailConfirmed")
                .HasDefaultValue(false)
                .IsRequired();

            builder.Property(p => p.Address1)
                .HasColumnName("sAddressLine1")
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(p => p.Address2)
                .HasColumnName("sAddressLine2")
                .HasMaxLength(256);

            builder.Property(p => p.Address3)
                .HasColumnName("sAddressLine3")
                .HasMaxLength(256);

            builder.Property(p => p.City)
                .HasColumnName("sCity")
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(p => p.StateProvinceID)
                .HasColumnName("fkStateProvinceID")
                .IsRequired();

            builder.Property(p => p.ZipCode)
                .HasColumnName("sZipCode")
                .HasMaxLength(25)
                .IsRequired();

            builder.Property(p => p.URL)
                .HasColumnName("sURL")
                .HasMaxLength(256);

            builder.Property(p => p.BusinessHours)
                .HasColumnName("sBusinessHours")
                .HasMaxLength(1000);

            builder.Property(p => p.TimeZoneID)
                .HasColumnName("fkTimeZoneID")
                .IsRequired();

            builder.Property(p => p.StripeCustomerID)
                .HasColumnName("sStripeCustomerID");

            builder.Property(p => p.StripeCreateCustomerDetails)
                .HasColumnName("sStripeCreateCustomerDetails");

            builder.Property(p => p.SubscriptionType)
                .HasColumnName("sSubscriptionType")
                .HasMaxLength(256); //TODO - use enum, possibly change spot

            builder.Property(p => p.SubscriptionExpirationDateUTC)
                .HasColumnName("dtSubscriptionExpirationUTC")
                .IsRequired();
        }
    }
}
