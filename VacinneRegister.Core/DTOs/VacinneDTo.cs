using System;
using VacinneRegister.Core.Entities;

namespace VacinneRegister.Core.DTOs
{
    public class VacinneDTo : BaseClass
    {
        public string Name { get; set; }

        public DateTime ApplicationDate { get; set; }

        public int MunicipalityId { get; set; }
    }
}
