using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace BlazorWithMongo.Shared.Models
{
    public class Dish : MongoDocument
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Price { get; set; }
    }
}
