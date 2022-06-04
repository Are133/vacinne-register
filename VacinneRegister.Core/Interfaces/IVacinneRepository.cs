using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VacinneRegister.Core.Entities;

namespace VacinneRegister.Core.Interfaces
{
    public interface IVacinneRepository
    {
        Task<IEnumerable<Vacinne>> GetVacinnes();

        Task<Vacinne> RegisterVacinne(Vacinne vacinne);

        Task<Vacinne> FindBydIdVacinne(int id);
        Task<bool> UpdateVacinne(Vacinne vacinne);

        Task<bool> DeleteVacinne(int id);

    }
}
