using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;

namespace MongoDb.Data.Models
{
    public class Film
    {
        public ObjectId Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

        [Required]
        public int Year { get; set; }
    }
}
