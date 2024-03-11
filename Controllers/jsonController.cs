using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace JsonResponseAPI.Controllers
{
    [Route("json")]
    public class jsonController : Controller
    {
        public string Index()
        {
            var jsonList = new List<string>();
            var bookList = new List<Book>();

            for (int i = 1; i <= 10; i++)
            {
                Book book = new Book
                {
                    Title = "TitleTest",
                    Author = "AuthorTest",
                    publishedYear = 2021,
                    Genres = new List<string> { "Genre1", "Genre2" },
                    Characters = new List<string> { "Character1", "Character2" }
                };

                bookList.Add(book);
            }

            jsonList.Add(@"
            {
                ""name"": ""John Doe"",
                ""age"": 30,
                ""city"": ""New York"",
                ""isStudent"": false,
                ""hobbies"": [""reading"", ""hiking"", ""cooking""],
                ""address"": {
                    ""street"": ""123 Main Street"",
                    ""city"": ""New York"",
                    ""zipcode"": ""10001""
                }
            }");

            jsonList.Add(@"
            {
              ""productId"": ""ABC123"",
              ""productName"": ""Widget"",
              ""price"": 19.99,
              ""inStock"": true,
              ""categories"": [""electronics"", ""gadgets""],
              ""description"": ""A versatile widget with multiple functions."",
              ""dimensions"": {
                ""length"": 10,
                ""width"": 5,
                ""height"": 3
              },
              ""manufacturer"": {
                ""name"": ""TechCo"",
                ""location"": ""San Francisco""
              }
            }");           
            
            jsonList.Add(@"{
              ""title"": ""To Kill a Mockingbird"",
              ""author"": ""Harper Lee"",
              ""publishedYear"": 1960,
              ""genres"": [""Novel"", ""Southern Gothic"", ""Legal drama""],
              ""ratings"": {
                ""goodreads"": 4.28,
                ""amazon"": 4.7
              },
              ""characters"": [""Atticus Finch"", ""Scout Finch"", ""Jem Finch"", ""Boo Radley""],
              ""publisher"": {
                ""name"": ""J. B. Lippincott & Co."",
                ""location"": ""Philadelphia""
              }
            }");

            // random int between 0 and 2
            var random = new Random();
            var index = random.Next(0, 3);

            string response = JsonConvert.SerializeObject(bookList, Formatting.Indented);

            return response;
            //return jsonList[index];
            //return View();
        }

        public class Book
        {
            public string Title { get; set; }
            public string Author { get; set; }
            public int publishedYear { get; set; }
            public List<string> Genres { get; set; }
            public List<string> Characters { get; set; }
        }

    }
}
