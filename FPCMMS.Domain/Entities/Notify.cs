namespace FPCMMS.Domain.Entities
{
    public class Notify
    {

        public int Id { get; set; }
        public string WeaponDescription { get; set; }
        public string? Attachments { get; set; }
        public ICollection<NotifyItem> NotifyItems { get; set; }
    }
}
