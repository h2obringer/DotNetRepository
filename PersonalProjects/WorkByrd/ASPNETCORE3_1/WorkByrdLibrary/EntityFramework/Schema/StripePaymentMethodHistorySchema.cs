using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WorkByrdLibrary.EntityFramework.Tables;
using WorkByrdLibrary.Objects;

namespace WorkByrdLibrary.EntityFramework.Schema
{
    public class StripePaymentMethodHistorySchema : IEntityTypeConfiguration<StripePaymentMethodHistory>
    {
        public void Configure(EntityTypeBuilder<StripePaymentMethodHistory> builder)
        {
            builder.ToTable("StripePaymentMethodHistory")
                .HasKey(p => p.ID);

            builder.Property(p => p.ID)
                .HasColumnName("ID")
                .HasMaxLength(36);

            builder.Property(p => p.PaymentMethodID)
                .HasColumnName("PaymentMethod_ID")
                .HasMaxLength(36);

            builder.Property(p => p.CompanyID)
                .HasColumnName("fkCompanyID")
                .HasMaxLength(36);

            builder.Property(p => p.StripeID)
                .HasColumnName("sStripeID")
                .HasMaxLength(50);

            builder.Property(p => p.Type)
                .HasColumnName("sType")
                .HasMaxLength(36);

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
                .HasColumnName("dtCreatedDateUTC");

            builder.Property(p => p.IsActive)
                .HasColumnName("bActive");

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
