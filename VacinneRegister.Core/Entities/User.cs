using System.Collections.Generic;

namespace VacinneRegister.Core.Entities
{
    public class User : BaseClass
    {
        public string IdUser { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Telefono { get; set; }

        public int Edad { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public IEnumerable<Vacinne> VacinnesRegisterForThisUser { get; }
    }
}
