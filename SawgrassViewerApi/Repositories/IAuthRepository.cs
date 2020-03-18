using SawgrassViewerApi.DTOs;
using SawgrassViewerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SawgrassViewerApi.Repositories
{
    public interface IAuthRepository
    {
        Task<UserForLoginDto> Login(string username, string password);

        #region Test User Registration ##### DISABLED unless new test user needed ####
        //Task<User> Register(User user, string password);
        //Task<bool> UserExists(string username);
        #endregion
        bool IsADUser(string domain, string user, string password);
    }
}
