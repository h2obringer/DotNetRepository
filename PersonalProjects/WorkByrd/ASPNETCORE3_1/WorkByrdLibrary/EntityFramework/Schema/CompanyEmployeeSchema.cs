using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkByrdLibrary.EntityFramework.Tables;

namespace WorkByrdLibrary.EntityFramework.Schema
{
    public class CompanyEmployeeSchema : IEntityTypeConfiguration<CompanyEmployee>
    {
        public void Configure(EntityTypeBuilder<CompanyEmployee> builder)
        {
            builder.ToTable("CompanyEmployee")
                .HasKey(p => p.ID);
            //TODO - add unique constaint or composite key...
            //https://www.learnentityframeworkcore.com/configuration/fluent-api/haskey-method
            //https://stackoverflow.com/questions/21573550/setting-unique-constraint-with-fluent-api

            builder.Property(p => p.ID)
                .HasColumnName("ID")
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(p => p.CompanyID)
                .HasColumnName("fkCompanyID")
                .HasMaxLength(256)
                .IsRequired(); //FK

            builder.Property(p => p.UserID)
                .HasColumnName("fkAspNetUsersID")
                .HasMaxLength(256)
                .IsRequired(); //FK
        }
    }
}
