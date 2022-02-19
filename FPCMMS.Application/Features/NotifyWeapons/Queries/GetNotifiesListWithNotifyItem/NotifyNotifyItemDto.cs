using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPCMMS.Application.Features.NotifyWeapons.Queries.GetNotifiesListWithNotifyItem
{
    public class NotifyNotifyItemDto
    {
        public int NotifyItemId { get; set; }
        public string WeaponName { get; set; }
        public string WeaponType { get; set; }
        public int Quantity { get; set; }
        public int NotifyId { get; set; }
    }
}
