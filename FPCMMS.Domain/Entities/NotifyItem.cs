using System.ComponentModel.DataAnnotations.Schema;

namespace FPCMMS.Domain.Entities
{
    public class NotifyItem
    {
        public int Id { get; set; }
        public string WeaponName { get; set; }
        public string WeaponType { get; set; }
        public int Quantity { get; set; }
        public int NotifiesId { get; set; }
        public Notify Notify { get; set; }
    }
}
