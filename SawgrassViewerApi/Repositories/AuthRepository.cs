using SawgrassViewerApi.DTOs;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SawgrassViewerApi.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        //private readonly DataContext _context;

        //public AuthRepository(DataContext context)
        //{
        //    _context = context;
        //}

        public async Task<UserForLoginDto> Login(string username, string password)
        {
            var user = new UserForLoginDto
            {
                Username = username,
                Password = password
            };

            if (user == null)
                return null;

            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                        return false;
                }
            }

            return true;

        }

        //public async Task<User> Register(User user, string password)
        //{
        //    byte[] passwordHash, passwordSalt;
        //    CreatePasswordHash(password, out passwordHash, out passwordSalt);

        //    user.PasswordHash = passwordHash;
        //    user.PasswordSalt = passwordSalt;

        //    await _context.Users.AddAsync(user);
        //    await _context.SaveChangesAsync();

        //    return user;
        //}

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        //public async Task<bool> UserExists(string username)
        //{
        //    if (await _context.Users.AnyAsync(u => u.username == username))
        //    {
        //        return true;
        //    }

        //    return false;
        //}

        public bool IsADUser(string domain, string user, string password)
        {
            bool isValid = false;

            using (var pc = new PrincipalContext(ContextType.Domain, "HPCI"))
            {
                isValid = pc.ValidateCredentials(user, password);

            }

            return isValid;
        }
    }
}
