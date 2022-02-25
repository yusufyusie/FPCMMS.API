using AutoMapper;
using FPCMMS.Application.DTOs.Notify;
using FPCMMS.Application.DTOs.NotifyItem;
using FPCMMS.Application.Features.Weapon.NotifyComands;
using FPCMMS.Application.Features.Weapon.NotifyDetailCommands;
using FPCMMS.Application.Features.Weapon.NotifyDetailQueries;
using FPCMMS.Application.Features.Weapon.NotifyQueries;
using FPCMMS.Domain.Entities;

namespace FPCMMS.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Notify, NotifyWeaponDto>();
            CreateMap<Notify, NotifyForCreationDto>().ReverseMap();
            CreateMap<Notify, CreateNotifyCommand>().ReverseMap();

            CreateMap<GetAllNotifyQuery, GetAllNotifyParameter>();
            CreateMap<Notify, UpdateNotifyCommand>().ReverseMap();
            CreateMap<Notify, NotifyWeaponForUpdateDto>();
            CreateMap<Notify, GetAllNotifyVm>().ReverseMap();
            CreateMap<Notify, NotifyListVm>();
            CreateMap<Notify, NotifyNotifyItemListVm>();

            CreateMap<NotifyItem, NotifyItemDto>();
            CreateMap<NotifyItem, NotifyItemForCreationDto>().ReverseMap();
            CreateMap<NotifyItem, CreateNotifyDetailCommand>().ReverseMap();
            CreateMap<NotifyItem, NotifyListVm>().ReverseMap();
            CreateMap<NotifyItem, CreateNotifyDetailCommand>().ReverseMap();
            CreateMap<NotifyItem, UpdateNotifyDetailCommand>().ReverseMap();
            CreateMap<NotifyItem, NotifyDetailVm>().ReverseMap();
            CreateMap<NotifyItem, NotifyNotifyItemDto>().ReverseMap();

        }
    }
}
