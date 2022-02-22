using FPCMMS.Application.DTOs;
using FPCMMS.Application.DTOs.Notify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPCMMS.Application.Features.NotifyItems.Queries.GetNotifyDetail
{
    public class NotifyDetailVm
    {        
        public int Id { get; set; }
        public string WeaponName { get; set; }
        public string WeaponType { get; set; }
        public int Quantity { get; set; }
        public int NotifiesId { get; set; }
        public NotifyWeaponDto Notify { get; set; }
    }
}
