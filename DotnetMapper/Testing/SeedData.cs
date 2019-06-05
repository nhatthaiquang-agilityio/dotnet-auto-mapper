using System.Collections.Generic;
using DotnetMapper.Models;
using MongoDB.Driver;

namespace Testing
{
    public static class SeedData
    {
        public static void InitData()
        {
            CreateBooks();
        }

        private static void CreateBooks()
        {
            var book1 = new Book
            {
                Author = "Stephen Ken",
                Price = (decimal)43.45,
                Category = "Program",
                BookName = "Basic C#"
            };

            var book2 = new Book
            {
                Author = "John Wick",
                Price = (decimal)53.45,
                Category = "Program",
                BookName = "Thinking Python"
            };

            var newBooks = new List<Book> { book1, book2 };

            var client = new MongoClient("mongodb://root:example@localhost:27017");
            IMongoDatabase db = client.GetDatabase("BookDB");
            var collection = db.GetCollection<Book>("Books");

            collection.InsertMany(newBooks);

        }
    }
}
