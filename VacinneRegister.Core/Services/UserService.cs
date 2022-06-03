using System.Collections.Generic;
using System.Threading.Tasks;
using VacinneRegister.Core.Entities;
using VacinneRegister.Core.Interfaces;

namespace VacinneRegister.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _userRepository.GetUsers();
        }

        public async Task RegisterUser(User user, string password)
        {
            await _userRepository.RegisterUser(user, password);
        }
    }
}
