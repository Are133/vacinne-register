using VacinneRegister.Core.Entities;

namespace VacinneRegister.Core.DTOs
{
    public class UserDTo : BaseClass
    {
        public string IdUser { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Telefono { get; set; }

        public int Edad { get; set; }

        public string Password { get; set; }
    }
}
