using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DotnetMapper;
using DotnetMapper.Models;
using Newtonsoft.Json;
using Xunit;

namespace Testing
{
    // Integration Test
    public class BooksControllerTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public BooksControllerTests(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();

            //TODO: need to seed data for testing
        }

        [Fact]
        public async Task TestCreateBook()
        {
            var bookModel = new BookViewModel
            {
                Author = "Max Lauren",
                Price = (decimal)43.45,
                Category = "Program",
                BookName = "Advance C#"
            };

            HttpContent content = new StringContent(
                JsonConvert.SerializeObject(bookModel), 
                Encoding.UTF8, "application/json");
            var httpResponse = await _client.PostAsync(
                "http://localhost/api/books", content);

            httpResponse.EnsureSuccessStatusCode();
       
            // Deserialize and examine results.
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var book = JsonConvert.DeserializeObject<Book>(stringResponse);

            Assert.Equal("Max Lauren", book.Author);
            Assert.Equal(43.45, (double)book.Price);
            Assert.NotNull(book.Id);
        }

        [Fact]
        public async Task TestGetListBooks()
        {
            var httpResponse = await _client.GetAsync("http://localhost/api/books");

            // Must be successful.
            httpResponse.EnsureSuccessStatusCode();

            // Deserialize and examine results.
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var books = JsonConvert.DeserializeObject<IEnumerable<Book>>(stringResponse);

            Assert.Contains(books, p => p.Author == "Rick Johnson");
            Assert.Contains(books, p => p.BookName == "Advance C#");
        }

        [Fact]
        public async Task TestGetBook()
        {
            var httpResponse = await _client.GetAsync("http://localhost/api/books/5cefa9cfa8af8905f4457ba1");

            // Must be successful.
            httpResponse.EnsureSuccessStatusCode();

            // Deserialize and examine results.
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var book = JsonConvert.DeserializeObject<Book>(stringResponse);

            Assert.Equal("Rick Johnson", book.Author);
            Assert.Equal(48.45, (double)book.Price);
            Assert.Equal("5cefa9cfa8af8905f4457ba1", book.Id);
        } 
    }
}
