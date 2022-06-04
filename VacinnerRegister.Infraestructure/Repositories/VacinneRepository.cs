using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using VacinneRegister.Core.Entities;
using VacinneRegister.Core.Interfaces;
using VacinnerRegister.Infraestructure.Data;

namespace VacinnerRegister.Infraestructure.Repositories
{
    public class VacinneRepository : IVacinneRepository
    {
        private readonly DataContext _dataContext;

        public VacinneRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<bool> DeleteVacinne(int id)
        {
            var currentVacine = await FindBydIdVacinne(id);

            _dataContext.Vacinnes.Remove(currentVacine);

            int rows = await _dataContext.SaveChangesAsync();

            return rows > 0;
        }

        public async Task<Vacinne> FindBydIdVacinne(int id)
        {
            var vacinne = await _dataContext.Vacinnes.FindAsync(id);

            return vacinne;
        }

        public async Task<IEnumerable<Vacinne>> GetVacinnes()
        {
            var vacinner = await _dataContext.Vacinnes.ToListAsync();
            return vacinner;
        }

        public async Task<Vacinne> RegisterVacinne(Vacinne vacinne)
        {
            await _dataContext.AddAsync(vacinne);
            Vacinne vacinneToDB = new Vacinne
            {
                Name = vacinne.Name,
                ApplicationDate = vacinne.ApplicationDate,
                Municipality = vacinne.Municipality
            };
            await _dataContext.SaveChangesAsync();
            return vacinneToDB;
        }

        public async Task<bool> UpdateVacinne(Vacinne vacinne)
        {
            var currentVacinne = await FindBydIdVacinne(vacinne.Id);

            currentVacinne.Name = vacinne.Name;
            currentVacinne.ApplicationDate = vacinne.ApplicationDate;

            int rows = await _dataContext.SaveChangesAsync();

            return rows > 0;
        }
    }
}
