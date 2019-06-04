using DotnetMapper.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace Testing
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<DotnetMapper.Startup>
    {

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddScoped<BookService>();
            });
        }
       
    }
}
