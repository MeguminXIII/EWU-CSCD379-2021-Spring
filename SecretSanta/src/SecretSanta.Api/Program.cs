using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using SecretSanta.Business;

namespace SecretSanta.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if(args[0].Equals("DeploySampleData")){
                SampleData.Seed();
            }
            
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
