using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VacinneRegister.API.Response;
using VacinneRegister.Core.DTOs;
using VacinneRegister.Core.Entities;
using VacinneRegister.Core.Interfaces;

namespace VacinneRegister.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;

        public UserController(IMapper mapper, IUserRepository userRepository, IUserService userService)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetUsers();

            var usersDTo = _mapper.Map<IReadOnlyList<UserDTo>>(users);

            var response = new APIResponse<IEnumerable<UserDTo>>(usersDTo);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserDTo userDTo)
        {

            var user = _mapper.Map<User>(userDTo);

            await _userService.RegisterUser(user, userDTo.Password);

            userDTo = _mapper.Map<UserDTo>(user);

            var response = new APIResponse<UserDTo>(userDTo);

            return Ok(response);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserDTo user)
        {
            var response = await _userRepository.Login(user.Email, user.Password);

            if (response == "nuser")
            {
                return BadRequest("CredentialsIncorrect");
            }
            if (response == "CredentialsIncorrect")
            {
                return BadRequest("CredentialsIncorrect");
            }

            return Ok($"Usuario Logueado {response}");
        }
    }
}
