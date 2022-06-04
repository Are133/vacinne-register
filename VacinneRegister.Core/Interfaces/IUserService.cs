using System.Collections.Generic;
using System.Threading.Tasks;
using VacinneRegister.Core.Entities;

namespace VacinneRegister.Core.Interfaces
{
    public interface IUserService
    {
        Task RegisterUser(User user, string password);

        Task<IEnumerable<User>> GetUsers();
    }
}
