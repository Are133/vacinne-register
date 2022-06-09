using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using VacinneRegister.Core.Entities;
using VacinneRegister.Core.Interfaces;
using VacinnerRegister.Infraestructure.Data;

namespace VacinnerRegister.Infraestructure.Repositories
{
    public class MunicipalityRepository : IMunicipalityRepository
    {
        private readonly DataContext _dataContext;

        public MunicipalityRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> DeleteMunicipality(int id)
        {
            var currentMunicipality = await FindBydIdMunicipality(id);

            _dataContext.Municipalities.Remove(currentMunicipality);

            int rows = await _dataContext.SaveChangesAsync();

            return rows > 0;
        }

        public async Task<Municipality> FindBydIdMunicipality(int id)
        {
            var municipality = await _dataContext.Municipalities.FindAsync(id);

            return municipality;
        }

        public async Task<IEnumerable<Municipality>> GetMunicipalities()
        {
            var municipality = await _dataContext.Municipalities.ToListAsync();
            return municipality;
        }

        public async Task<Municipality> RegisterMunicipality(Municipality municipality)
        {
            await _dataContext.AddAsync(municipality);
            Municipality municipalityDTO = new Municipality
            {
                Name = municipality.Name,
            };
            await _dataContext.AddAsync(municipality);
            await _dataContext.SaveChangesAsync();
            return municipalityDTO;
        }
        public async Task<bool> UpdateMunicipality(Municipality municipality)
        {
            var currentMunicipality = await FindBydIdMunicipality(municipality.Id);

            currentMunicipality.Name = municipality.Name;

            int rows = await _dataContext.SaveChangesAsync();

            return rows > 0;
        }
    }
}
