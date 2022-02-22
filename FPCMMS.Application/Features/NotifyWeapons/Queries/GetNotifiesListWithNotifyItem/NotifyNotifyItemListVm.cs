using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPCMMS.Application.Features.NotifyWeapons.Queries.GetNotifiesListWithNotifyItem
{
    public class NotifyNotifyItemListVm
    {
        public int Id { get; set; }
        public string WeaponDescription { get; set; }
        public string Attachments { get; set; }
        public ICollection<NotifyNotifyItemDto> NotifyItems { get; set; }
    }
}
