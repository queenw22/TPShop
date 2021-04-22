using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ServiceConfig : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.Property(s => s.Id).IsRequired();
            builder.Property(s => s.Name).IsRequired().HasMaxLength(100);
            builder.Property(s => s.Number).IsRequired();
            builder.Property(s => s.Address).IsRequired(false);
            builder.Property(s => s.Theme).IsRequired().HasMaxLength(500);
            builder.Property(s => s.Price).HasColumnType("decimal(18,2");
            builder.Property(s => s.DateOfService).IsRequired().HasColumnType("Date");
            builder.HasOne(t => t.ServiceType).WithMany().HasForeignKey(s => s.ServiceTypeId);
            builder.HasOne(t => t.CommType).WithMany().HasForeignKey(s => s.CommTypeId);
            builder.HasOne(t => t.DesignOptions).WithMany().HasForeignKey(s => s.DesignOptionsId);
            builder.Property(s => s.CommType).IsRequired(false);
            builder.Property(s => s.CommTypeId).IsRequired(false);
            builder.Property(s => s.DesignOptions).IsRequired(false);
            builder.Property(s => s.DesignOptionsId).IsRequired(false);



            




        }
    }
}