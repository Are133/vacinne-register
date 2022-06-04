using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VacinneRegister.Core.Entities;

namespace VacinnerRegister.Infraestructure.Data.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.LastNames).IsRequired().HasMaxLength(100);
            builder.Property(p => p.CURP).IsRequired().HasMaxLength(18);
        }
    }
}
