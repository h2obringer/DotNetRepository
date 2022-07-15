using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkByrdLibrary.EntityFramework.Tables;

namespace WorkByrdLibrary.EntityFramework.Schema
{
    public class StripePaymentMethodSchema : IEntityTypeConfiguration<StripePaymentMethod>
    {
        public void Configure(EntityTypeBuilder<StripePaymentMethod> builder)
        {
            builder.ToTable("StripePaymentMethod")
                .HasKey(p => p.ID);

            builder.Property(p => p.ID)
                .HasColumnName("ID")
                .HasMaxLength(36)
                .IsRequired();

            builder.Property(p => p.CompanyID)
                .HasColumnName("fkCompanyID") //FK
                .HasMaxLength(36)
                .IsRequired();

            builder.Property(p => p.StripeID)
                .HasColumnName("sStripeID")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.Type)
                .HasColumnName("sType")
                .HasMaxLength(36)
                .IsRequired();

            builder.Property(p => p.BillingEmail)
                .HasColumnName("sBillingEmail")
                .HasMaxLength(256);

            builder.Property(p => p.BillingZipCode)
                .HasColumnName("sBillingZipCode")
                .HasMaxLength(25);

            builder.Property(p => p.CardBrand)
                .HasColumnName("sCardBrand")
                .HasMaxLength(50);

            builder.Property(p => p.CardExpirationMonth)
                .HasColumnName("iCardExpMonth");

            builder.Property(p => p.CardExpirationYear)
                .HasColumnName("iCardExpYear");

            builder.Property(p => p.CardFundingType)
                .HasColumnName("sCardFundType")
                .HasMaxLength(20);

            builder.Property(p => p.CardLast4)
                .HasColumnName("sCardLastFour")
                .HasMaxLength(5);

            builder.Property(p => p.CardCountry)
                .HasColumnName("sCardCountry")
                .HasMaxLength(50);

            builder.Property(p => p.CreatedDate)
                .HasColumnName("dtCreatedDateUTC")
                .IsRequired();

            builder.Property(p => p.IsActive)
                .HasColumnName("bActive")
                .HasDefaultValue(true)
                .IsRequired();
        }

    }
}
