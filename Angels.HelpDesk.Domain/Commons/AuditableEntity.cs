namespace Angels.HelpDesk.Domain.Commons
{
    public abstract class AuditableEntity
    {
        virtual public string Id { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastModified { get; set; } = DateTime.Now;
    }
}
