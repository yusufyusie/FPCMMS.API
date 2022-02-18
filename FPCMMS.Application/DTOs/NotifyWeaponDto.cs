using System.ComponentModel.DataAnnotations.Schema;

namespace FPCMMS.Application.DTOs
{
    public class NotifyWeaponDto
    {        
        public int Id { get; set; }
        public string WeaponDescription { get; set; }
        public string Attachment { get; set; }
    }
}

