using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkByrdLibrary.EntityFramework.Tables;

namespace WorkByrdLibrary.EntityFramework.Schema
{
    public class StateProvinceSchema : IEntityTypeConfiguration<StateProvince>
    {
        public void Configure(EntityTypeBuilder<StateProvince> builder)
        {
            builder.ToTable("StateProvince")
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
                .HasMaxLength(5)
                .IsRequired();

            builder.Property(p => p.CountryID)
                .HasColumnName("fkCountryID")
                .IsRequired(); //FK

            builder.Property(p => p.HasTaxNexus)
                .HasColumnName("bHasTaxNexus")
                .IsRequired();

            //TODO - build foreign key references here...
        }
    }
}
