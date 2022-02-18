using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPCMMS.Application.DTOs
{
    public abstract class NotifyItemForManipulationDto
    {      
        public string WeaponName { get; set; }
        public string WeaponType { get; set; }
        public int Quantity { get; set; }       
    }
}
