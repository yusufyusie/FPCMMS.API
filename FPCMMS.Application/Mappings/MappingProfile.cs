using AutoMapper;
using FPCMMS.Application.DTOs;
using FPCMMS.Application.Features.NotifyWeapons.Commands.CreateNotifyWeapon;
using FPCMMS.Application.Features.NotifyWeapons.Commands.UpdateNotifyWeapon;
using FPCMMS.Application.Features.NotifyWeapons.Queries.GetAllNotifyWeapons;
using FPCMMS.Domain.Entities;

namespace FPCMMS.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<NotifyWeapon, NotifyWeaponDto>();
            CreateMap<NotifyWeapon, NotifyWeaponForCreationDto>();
            CreateMap<NotifyWeapon, CreateNotifyWeaponCommand>().ReverseMap();

            CreateMap<GetAllNotifyWeaponsQuery, GetAllNotifyWeaponsParameter>();
            CreateMap<NotifyWeapon, UpdateNotifyWeaponCommand>().ReverseMap();
            CreateMap<NotifyWeapon, NotifyWeaponForUpdateDto>();
            CreateMap<NotifyWeapon, GetAllNotifyWeaponsViewModel>().ReverseMap();

        }
    }
}
