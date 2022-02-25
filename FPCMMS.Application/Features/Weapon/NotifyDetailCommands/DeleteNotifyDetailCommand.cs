using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPCMMS.Application.Features.Weapon.NotifyDetailCommands
{
    public class DeleteNotifyDetailCommand : IRequest
    {
        public int Id { get; set; }
    }
}
