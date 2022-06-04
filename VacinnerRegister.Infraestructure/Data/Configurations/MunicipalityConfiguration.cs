using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VacinneRegister.Core.Entities;

namespace VacinnerRegister.Infraestructure.Data.Configurations
{
    public class MunicipalityConfiguration : IEntityTypeConfiguration<Municipality>
    {
        public void Configure(EntityTypeBuilder<Municipality> builder)
        {
            builder.Property(m => m.Name).IsRequired().HasMaxLength(100);
        }
    }
}
