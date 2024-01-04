using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DotnetMongoCase.Models.Contacts
{
    public class Contact
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; } = null!;
        [BsonRepresentation(BsonType.ObjectId)]
        public string CompanyId { get; set; }

        [BsonIgnoreIfNull]
        public string? CompanyName { get; set; } 
    }
}
