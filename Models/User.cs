using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace Web_application_for_managing_accessories_store.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string name { get; set; } = null!;
        public string email { get; set; } = null!;
        public string password { get; set; } = null!;
    }
}
