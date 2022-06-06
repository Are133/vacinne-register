using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VacinneRegister.Core.Entities;
using VacinneRegister.Core.Interfaces;
using VacinnerRegister.Infraestructure.Data;

namespace VacinnerRegister.Infraestructure.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly DataContext _dataContext;

        public PersonRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<Person> RegisterPerson(Person person)
        {

            Person personToDB = new Person
            {
                Name = person.Name,
                LastNames = person.LastNames,
                CURP = person.CURP,
                IdMunicipality = person.IdMunicipality,
                IdVacinne = person.IdVacinne
            };
            await _dataContext.SaveChangesAsync();
            return personToDB;
        }

        public async Task<List<MunicipalityAndVacines>> GetPersonsAndVacinnes(int id)
        {
            var vp = (from v in _dataContext.Vacinnes
                      where v.MunicipalityId == id
                      select new MunicipalityAndVacines
                      {
                          Value = v.Id,
                          Text = v.Name

                      }).ToListAsync();

            //lista = (from d in db.Animals
            //         where d.Id_Clase == idAnimalClass
            //         select new ElementJsonIntKey
            //         {
            //             Value = d.Id,
            //             Text = d.Name
            //         }).ToList();


            //var vp = (from vaccines in _dataContext.Vacinnes
            //        join munipalities in _dataContext.Municipalities on
            //        vaccines.Id equals munipalities.Id
            //        select new MunicipalityAndVacines
            //        {
            //            Value = vaccines.Id,
            //            Text = vaccines.Name

            //        }).ToListAsync();
            Console.WriteLine(vp);
            return await vp;
            
        }
    }
}

