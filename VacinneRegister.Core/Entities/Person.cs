using System.Collections.Generic;

namespace VacinneRegister.Core.Entities
{
    public class Person : BaseClass
    {
        public string Name { get; set; }

        public string LastNames { get; set; }

        public string CURP { get; set; }
        public int IdVacinne { get; set; }

        public int IdMunicipality { get; set; }

        public Municipality Municipality { get; set; }

        public Vacinne Vacinne { get; set; }
    }
}
