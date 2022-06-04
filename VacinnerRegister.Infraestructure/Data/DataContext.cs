using Microsoft.EntityFrameworkCore;
using VacinneRegister.Core.Entities;
using VacinnerRegister.Infraestructure.Data.Configurations;

namespace VacinnerRegister.Infraestructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Municipality> Municipalities { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vacinne> Vacinnes { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.ApplyConfiguration(new MunicipalityConfiguration());
            model.ApplyConfiguration(new PersonConfiguration());
            model.ApplyConfiguration(new UserConfiguration());
            model.ApplyConfiguration(new VacinneConfiguration());
        }
    }
}
