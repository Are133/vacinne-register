using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using VacinneRegister.Core.DTOs;
using VacinneRegister.Core.Entities;
using VacinneRegister.Core.Interfaces;
using VacinnerRegister.Infraestructure.Data;

namespace VacinnerRegister.Infraestructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;

        private readonly Microsoft.Extensions.Configuration.IConfiguration _configuration;

        public UserRepository(DataContext dataContext, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            _dataContext = dataContext;
            _configuration = configuration;

        }
        public async Task<string> Login(string email, string password)
        {
            var user = await _dataContext
                .Users
                .FirstOrDefaultAsync(u => u.Email.ToLower().Equals(email.ToLower()));

            if (user == null)
            {
                return "nuser";
            }
            if (!VerifiedPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                return "CredentialsIncorrect";
            }
            else
            {
                return CreateToken(user);
            }
        }

        public async Task<int> RegisterUser(User user, string password)
        {
            if (await UserExist(user.Email))
            {
                return -1;
            }
            try
            {
                CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;

                var userToDB = new User
                {
                    IdUser = GenerateKeyUser().Trim(),
                    Name = user.Name,
                    LastName = user.LastName,
                    Email = user.Email,
                    Telefono = user.Telefono,
                    Edad = user.Edad,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt
                };
                await _dataContext.Users.AddAsync(userToDB);
                await _dataContext.SaveChangesAsync();
                return userToDB.Id;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task<bool> UserExist(string email)
        {
            if (await _dataContext.Users.AnyAsync(u => u.Email.ToLower().Equals(email.ToLower())))
            {
                return true;
            }
            return false;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public string GenerateKeyUser()
        {
            DateTime dateTime = DateTime.Now;
            Guid userGuid = Guid.NewGuid();
            string dateTimeString = Convert.ToString(dateTime);
            string idUser = $"{userGuid} {dateTimeString}";

            return idUser;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _dataContext.Users.ToListAsync();
            return users;
        }

        public bool VerifiedPasswordHash(string password, byte[] passwordHash, byte[] passwordSolt)
        {
            using (var hmac = new HMACSHA512(passwordSolt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        public string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Email),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(3),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
