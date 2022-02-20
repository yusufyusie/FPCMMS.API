using FPCMMS.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace FPCMMS.Domain.Entities
{
    public class Notify
    {

        [Column("NotifyId")]
        public int Id { get; set; }       
        public string WeaponDescription { get; set; }
        public string Attachment { get; set; }
        public ICollection<NotifyItem> NotifyItems { get; set; }
    }
}
