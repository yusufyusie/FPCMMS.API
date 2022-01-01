namespace FPCMMS.Domain.Common
{
    public class AuditableEntity
    {
        public Guid Id { get; set; }
        public string? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTimeOffset? ModifiedDate { get; set; }
    }
}
