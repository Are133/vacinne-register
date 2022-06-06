using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VacinneRegister.Core.Entities;

namespace VacinneRegister.Core.Interfaces
{
    public interface IPersonRepository
    {
        Task<Person> RegisterPerson(Person person);

        Task<List<MunicipalityAndVacines>> GetPersonsAndVacinnes(int id);
    }
}
