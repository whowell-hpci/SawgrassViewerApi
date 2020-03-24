using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SawgrassViewerApi.DTOs;
using SawgrassViewerApi.Models;
using SawgrassViewerApi.Repositories;

namespace SawgrassViewerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public AuthController(IAuthRepository repo, IConfiguration config, IMapper mapper)
        {
            _repo = repo;
            _config = config;
            _mapper = mapper;
        }

        #region Test User Registration ##### DISABLED unless new test user needed ####
        //[HttpPost("register")]
        //public async Task<IActionResult> Register(UserForRegistrationDto userForRegistrationDto)
        //{
        //    // Reqeust Validated through DTO and [APIController]

        //    userForRegistrationDto.Username = userForRegistrationDto.Username.ToLower();

        //    if (await _repo.UserExists(userForRegistrationDto.Username))
        //    {
        //        return BadRequest("Username already exists");
        //    }

        //    //Automapper to map the DTO back to the User object
        //    var userToCreate = _mapper.Map<User>(userForRegistrationDto);

        //    var createdUser = await _repo.Register(userToCreate, userForRegistrationDto.Password);

        //    var userToReturn = _mapper.Map<UserForReturnDto>(createdUser);

        //    return Ok(userToReturn);

        //}
        #endregion
       
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var userValidated = _repo.IsADUser("hpci", userForLoginDto.Username, userForLoginDto.Password);

            if (!userValidated)
                return Unauthorized("AD Authorization Error");


            var claims = new[]
            {
                new Claim(ClaimTypes.Name, userForLoginDto.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var user = _mapper.Map<UserForReturnDto>(userForLoginDto);

            return Ok(new
            {
                token = tokenHandler.WriteToken(token),
                user
            });
        }
    }
}
