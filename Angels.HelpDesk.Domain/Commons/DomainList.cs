using Angels.HelpDesk.Domain.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace Angels.HelpDesk.Domain.Commons
{
    public class DomainList : AuditableEntity
    {
        [BsonIgnoreIfNull]
        public string ParentId { get; set; } = null;

        [BsonIgnoreIfNull]
        public string Text { get; set; } = null;

        [BsonIgnoreIfNull]
        public string Description { get; set; } = null;

        public Status Status { get; set; } = Status.Active;
    }
}
