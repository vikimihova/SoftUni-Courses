using Microsoft.EntityFrameworkCore;
using MongoDb.Data;
using MongoDb.Data.Models;
using MongoDB.Driver;

namespace MongoDb
{
    internal class Program
    {
        static async void Main(string[] args)
        {
            // 1. Create the MongoDB client
            // in a web application the Mongo client should be Singleton!
            MongoClient client = new MongoClient("mongodb://user:password@localhost:27017");

            // 2. Create builder for dbContext options
            // add MongoDB and pass the client and the database name
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseMongoDB(client, "cinema_db");

            // 3. Create the dbContext
            using var context = new ApplicationDbContext(optionsBuilder.Options);

            // create a film (ObjectId is generated automatically)
            Film film = new Film()
            {
                Name = "Lord of the Rings: The Fellowship of the Ring",
                Description = "Best movie ever made",
                Year = 2001
            };

            // add film to context
            await context.AddAsync(film);

            // save changes
            await context.SaveChangesAsync();
        }
    }
}
