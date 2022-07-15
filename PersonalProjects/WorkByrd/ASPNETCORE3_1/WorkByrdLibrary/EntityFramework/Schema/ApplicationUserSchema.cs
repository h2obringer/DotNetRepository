using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WorkByrdLibrary.EntityFramework.Tables;

namespace WorkByrdLibrary.EntityFramework.Schema
{
    public class ApplicationUserSchema : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            //Table name and other properties have already been built by base .NET Identity code...

            builder.Property(p => p.FirstName)
                .HasColumnName("FirstName")
                .HasMaxLength(256);

            builder.Property(p => p.LastName)
                .HasColumnName("LastName")
                .HasMaxLength(256);
        }
    }
}
