using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WorkByrdLibrary.EntityFramework.Tables;
using WorkByrdLibrary.Objects;

namespace WorkByrdLibrary.EntityFramework.Schema
{
    public class WorkByrdLogSchema : IEntityTypeConfiguration<WorkByrdLog>
    {
        public void Configure(EntityTypeBuilder<WorkByrdLog> builder)
        {
            builder.ToTable("WorkByrdLog")
                .HasKey(p=>p.ID);

            builder.Property(p => p.ID)
                .HasColumnName("ID")
                .HasMaxLength(256)
                .IsRequired();
            builder.Property(p => p.Message)
                .HasColumnName("sName");
            builder.Property(p => p.StackTrace)
                .HasColumnName("sExceptionStackTrace");
            builder.Property(p => p.InnerException)
                .HasColumnName("sInnerException");
            builder.Property(p => p.CreatedDateUTC)
                .HasColumnName("dtCreatedUTC");
            builder.Property(p => p.EntryPoint)
                .HasColumnName("iEntryPoint")
                .HasConversion(new EnumToNumberConverter<EntryPoint, int>()); //allow property mapping of database value to the EntryPoint enum value and vice versa
            builder.Property(p => p.Location)
                .HasColumnName("sLocation")
                .HasMaxLength(1000);
            builder.Property(p => p.LogLevel)
                .HasColumnName("iLogLevel")
                .HasConversion(new EnumToNumberConverter<LogLevel, int>()); //allow property mapping of database value to the LogLevel enum value and vice versa
            builder.Property(p => p.UserID)
                .HasColumnName("UserID")
                .HasMaxLength(256)
                .HasDefaultValue("");
        }
    }
}
