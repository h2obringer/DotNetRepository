using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WorkByrdLibrary.EntityFramework.Tables;
using WorkByrdLibrary.Objects;

namespace WorkByrdLibrary.EntityFramework.Schema
{
    public class UserAccessLogSchema : IEntityTypeConfiguration<UserAccessLog>
    {
        public void Configure(EntityTypeBuilder<UserAccessLog> builder)
        {
            builder.ToTable("UserAccessLog")
                .HasKey(p=>p.ID);

            builder.Property(p => p.ID)
                .HasColumnName("ID")
                .HasMaxLength(256)
                .IsRequired();
            builder.Property(p => p.UserName)
                .HasColumnName("sUserName")
                .HasMaxLength(256)
                .IsRequired();
            builder.Property(p => p.Action)
                .HasColumnName("iAction")
                .IsRequired()
                .HasConversion(new EnumToNumberConverter<UserAccessAction, int>()); //allow property mapping of database value to the UserAccessAction enum value and vice versa
            builder.Property(p => p.EntryPoint)
                .HasColumnName("iEntryPoint")
                .IsRequired();
            builder.Property(p => p.TimeStampUTC)
                .HasColumnName("dtTimeStampUTC")
                .IsRequired();
        }
    }
}
