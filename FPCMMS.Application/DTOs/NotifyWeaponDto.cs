using System.ComponentModel.DataAnnotations.Schema;

namespace FPCMMS.Application.DTOs
{
    public class NotifyWeaponDto
    {
        [Column("NotifyWeaponId")]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public string Attachment { get; set; }
    }
}

