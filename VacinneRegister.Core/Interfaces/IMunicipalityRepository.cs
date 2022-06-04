using System.Collections.Generic;
using System.Threading.Tasks;
using VacinneRegister.Core.Entities;

namespace VacinneRegister.Core.Interfaces
{
    public interface IMunicipalityRepository
    {
        Task<IEnumerable<Municipality>> GetMunicipalities();

        Task<Municipality> RegisterMunicipality(Municipality unicipality);

        Task<Municipality> FindBydIdMunicipality(int id);
        Task<bool> UpdateMunicipality(Municipality municipality);

        Task<bool> DeleteMunicipality(int id);
    }
}
