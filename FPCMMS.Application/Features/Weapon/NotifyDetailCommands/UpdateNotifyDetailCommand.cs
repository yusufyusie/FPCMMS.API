using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPCMMS.Application.Features.Weapon.NotifyDetailCommands
{
    public class UpdateNotifyDetailCommand : IRequest
    {
        public int Id { get; set; }
        public string WeaponName { get; set; }
        public string WeaponType { get; set; }
        public int Quantity { get; set; }
        public int NotifyId { get; set; }
        public string WeaponDescription { get; set; }
        public string Attachment { get; set; }
    }
}
