using System.Collections.Generic;
using DotnetMapper.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Testing
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<DotnetMapper.Startup>
    {
        private static readonly Dictionary<string, string> arrayDict =
            new Dictionary<string, string>
            {
                {"MongoDB:Database", "Test_BookDB"},

            };
  
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-2.2
            // Add database name for testing
            builder.ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.AddInMemoryCollection(arrayDict);
            })
            .ConfigureServices(services =>
            {
                services.AddScoped<BookService>();
            });

            SeedData.InitData();
        }
       
    }
}
