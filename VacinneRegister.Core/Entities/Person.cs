using System.Collections.Generic;

namespace VacinneRegister.Core.Entities
{
    public class Person : BaseClass
    {
        public string Name { get; set; }

        public string LastNames { get; set; }

        public string CURP { get; set; }

        public IEnumerable<Vacinne> Vacinnes { get; }

        public Municipality Municipality { get; set; }


    }
}
