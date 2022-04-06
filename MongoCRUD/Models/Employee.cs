using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoCRUD.Models
{
    public class Employee
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

        [BsonElement("name")]
        public string Name { get; set; } = "";

        [BsonElement("cardNumber")]
        public string CardNumber { get; set; } = "";

        [BsonElement("salary")]
        public decimal Salary { get; set; } = 0;
    }
}
