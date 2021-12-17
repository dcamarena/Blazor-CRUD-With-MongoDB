using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BlazorWithMongo.Shared.Models
{
    public class City : MongoDocument
    {
        public string CityName { get; set; }
    }
}
