using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using SecretSanta.Api.Tests.Business;
using Microsoft.Extensions.DependencyInjection;
using SecretSanta.Business;


namespace SecretSanta.Api.Tests
{
    public class WebApplicationFactory : WebApplicationFactory<Startup>
    {
        public TestableUserRepository Tur {get;} = new();

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(service => service.AddScoped<IUserRepository, TestableUserRepository>(_ => Tur));
        }
    }
}