using MongoDB.Bson.Serialization.Attributes;

namespace Angels.HelpDesk.Domain.Commons
{
    public class ReferencedValue
    {
        [BsonIgnoreIfNull]
        public string Id { get; set; } = null;

        [BsonIgnoreIfNull]
        public string Text { get; set; } = null;
    }
}
