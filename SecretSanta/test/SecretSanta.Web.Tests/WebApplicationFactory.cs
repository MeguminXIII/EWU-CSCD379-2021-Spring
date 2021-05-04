using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Testing;
using SecretSanta.Web.Api;
using SecretSanta.Web.Tests.Api;


namespace SecretSanta.Web.Tests
{
    public class WebApplicationFactory : WebApplicationFactory<Startup>
    {
        public TestableUserClient Tuc {get;} = new();

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(service => 
            {
                service.AddScoped<IUsersClient, TestableUserClient>(_ => Tuc);
            });
        }
    }
}