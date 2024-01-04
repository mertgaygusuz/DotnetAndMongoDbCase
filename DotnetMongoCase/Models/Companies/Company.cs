using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DotnetMongoCase.Models.Companies
{
    public class Company
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; } = null!;
        public int NumberOfEmployees { get; set; }
    }
}
