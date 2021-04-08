using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Shopping.API;
using System;

namespace Shopping.Tests
{
    public class ContainerResolver
    {
        public IServiceProvider ServiceProvider
        {
            get; set;
        }

        public ContainerResolver()
        {
            try
            {

                var hostBuilder = Host.CreateDefaultBuilder()
                    .ConfigureWebHost(webHost =>
                    {
                        // Add TestServer
                        webHost.UseTestServer();
                        webHost.UseStartup<Startup>();
                    });
                // Create and start up the host
                // var host = hostBuilder.Start();
                ServiceProvider = hostBuilder.Build().Services;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}