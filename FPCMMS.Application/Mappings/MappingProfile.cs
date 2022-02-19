using AutoMapper;
using FPCMMS.Application.DTOs;
using FPCMMS.Application.Features.NotifyItems.Commands.CreateNotifyItem;
using FPCMMS.Application.Features.NotifyItems.Commands.UpdateNotifyItem;
using FPCMMS.Application.Features.NotifyItems.Queries.GetNotifyDetail;
using FPCMMS.Application.Features.NotifyItems.Queries.GetNotifyList;
using FPCMMS.Application.Features.NotifyWeapons.Commands.CreateNotifyWeapon;
using FPCMMS.Application.Features.NotifyWeapons.Commands.UpdateNotifyWeapon;
using FPCMMS.Application.Features.NotifyWeapons.Queries.GetAllNotifyWeapons;
using FPCMMS.Application.Features.NotifyWeapons.Queries.GetNotifiesListWithNotifyItem;
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
            CreateMap<Notify, NotifyListVm>();
            CreateMap<Notify, NotifyNotifyItemListVm>();

            CreateMap<NotifyItem, NotifyItemDto>();
            CreateMap<NotifyItem, NotifyItemForCreationDto>().ReverseMap();
            CreateMap<NotifyItem, CreateNotifyItemCommand>().ReverseMap();
            CreateMap<NotifyItem, NotifyListVm>().ReverseMap();
            CreateMap<NotifyItem, CreateNotifyItemCommand>().ReverseMap();
            CreateMap<NotifyItem, UpdateNotifyItemCommand>().ReverseMap();
            CreateMap<NotifyItem, NotifyDetailVm>().ReverseMap();
            CreateMap<NotifyItem, NotifyNotifyItemDto>().ReverseMap();

        }
    }
}
