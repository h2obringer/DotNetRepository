using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkByrdLibrary.EntityFramework.Tables;

namespace WorkByrdLibrary.EntityFramework.Schema
{
    public class CountrySchema : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Country")
                .HasKey(p => p.ID);

            builder.Property(p => p.ID)
                .HasColumnName("ID")
                .UseIdentityColumn();

            builder.Property(p => p.Name)
                .HasColumnName("sName")
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(p => p.Abbreviation)
                .HasColumnName("sAbbreviation")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(p => p.IsActive)
                .HasColumnName("bActive")
                .HasDefaultValue(false)
                .IsRequired();

            builder.Property(p => p.ContinentID)
                .HasColumnName("fkContinentID")
                .IsRequired(); //FK
        }
    }
}
