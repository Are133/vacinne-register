using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VacinneRegister.Core.Entities;

namespace VacinnerRegister.Infraestructure.Data.Configurations
{
    public class VacinneConfiguration : IEntityTypeConfiguration<Vacinne>
    {
        public void Configure(EntityTypeBuilder<Vacinne> builder)
        {
            builder.Property(v => v.Name).IsRequired().HasMaxLength(100);
            builder.Property(v => v.ApplicationDate).IsRequired().HasColumnType("datetime");
        }
    }
}
