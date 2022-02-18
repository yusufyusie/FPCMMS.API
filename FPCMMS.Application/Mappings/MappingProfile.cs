using AutoMapper;
using FPCMMS.Application.DTOs;
using FPCMMS.Application.Features.NotifyItems.Commands.CreateNotifyItem;
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
            CreateMap<Notify, NotifyWeaponDto>();
            CreateMap<Notify, NotifyWeaponForCreationDto>().ReverseMap();
            CreateMap<Notify, CreateNotifyWeaponCommand>().ReverseMap();

            CreateMap<GetAllNotifyWeaponsQuery, GetAllNotifyWeaponsParameter>();
            CreateMap<Notify, UpdateNotifyWeaponCommand>().ReverseMap();
            CreateMap<Notify, NotifyWeaponForUpdateDto>();
            CreateMap<Notify, GetAllNotifyWeaponsViewModel>().ReverseMap();

            CreateMap<NotifyItem, NotifyItemDto>();
            CreateMap<NotifyItem, NotifyItemForCreationDto>().ReverseMap();
            CreateMap<NotifyItem, CreateNotifyItemCommand>().ReverseMap();

        }
    }
}
