using System;

namespace VacinneRegister.Core.Entities
{
    public class Vacinne : BaseClass
    {
        public string Name { get; set; }

        public DateTime ApplicationDate { get; set; }

        public int MunicipalityId { get; set; }
    }
}
