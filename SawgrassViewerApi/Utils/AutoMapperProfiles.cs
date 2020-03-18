using AutoMapper;
using SawgrassViewerApi.DTOs;
using SawgrassViewerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SawgrassViewerApi.Utils
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForReturnDto>();
            CreateMap<UserForRegistrationDto, User>();
            CreateMap<UserForLoginDto, UserForReturnDto>();
        }
    }
}
