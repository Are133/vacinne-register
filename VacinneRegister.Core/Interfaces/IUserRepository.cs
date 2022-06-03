using System.Collections.Generic;
using System.Threading.Tasks;
using VacinneRegister.Core.Entities;

namespace VacinneRegister.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<int> RegisterUser(User user, string password);
        Task<string> Login(string userName, string password);
        Task<bool> UserExist(string userName);

        Task<IEnumerable<User>> GetUsers();

        string GenerateKeyUser();

        bool VerifiedPasswordHash(string password, byte[] passwordHash, byte[] passwordSolt);

        string CreateToken(User user);
    }
}
