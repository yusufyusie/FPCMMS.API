using AutoMapper;
using FPCMMS.Application.DTOs;
using FPCMMS.Application.DTOs.User;
using FPCMMS.Infrastructure.Identity.Models;

namespace FPCMMS.WebAPI.Mapper
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<UserForRegistrationDto, ApplicationUser>();
            CreateMap<UserForUpdateDto, ApplicationUser>();
        }
    }
}
