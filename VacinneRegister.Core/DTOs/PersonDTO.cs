using System;
using System.Collections.Generic;
using System.Text;
using VacinneRegister.Core.Entities;

namespace VacinneRegister.Core.DTOs
{
    public class PersonDTO:BaseClass
    {
        public string Name { get; set; }

        public string LastNames { get; set; }

        public string CURP { get; set; }

        public int IdVacinne { get; set; }

        public int IdMunicipality { get; set; }
    }
}
