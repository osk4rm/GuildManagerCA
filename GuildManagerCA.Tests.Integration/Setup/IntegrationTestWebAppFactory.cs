using GuildManagerCA.Infrastructure.Persistence;
using GuildManagerCA.Tests.Integration.Setup.Auth;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Respawn;
using Respawn.Graph;
using System.Data.Common;
using Testcontainers.MsSql;

namespace GuildManagerCA.Tests.Integration.Setup
{
    public class IntegrationTestWebAppFactory : WebApplicationFactory<Program>, IAsyncLifetime
    {
        private readonly MsSqlContainer _container = new MsSqlBuilder()
            .WithExposedPort(4321)
            .Build();

        
        public string ContainerConnectionString { get; set; } = default!;

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                services.AddSingleton<IPolicyEvaluator, FakePolicyEvaluator>();
                services.AddMvc(opts => opts.Filters.Add(new FakeUserFilter()));

                var descriptor = services
                .SingleOrDefault(s => s.ServiceType == typeof(DbContextOptions<GuildManagerDbContext>));

                if (descriptor is not null)
                {
                    services.Remove(descriptor);
                }

                services.AddDbContext<GuildManagerDbContext>(options =>
                {
                    options.UseSqlServer(_container.GetConnectionString());
                });
            });
        }

        public async Task ResetDatabaseAsync(Respawner respawner)
        {
            await respawner.ResetAsync(_container.GetConnectionString());
        }

        public async Task InitializeAsync()
        {
            await _container.StartAsync();
            ContainerConnectionString = _container.GetConnectionString();
            //await InitializeRespawner();
        }

        public new async Task DisposeAsync()
        {
            await _container.StopAsync();
        }

        public HttpClient CreateClientWithoutAuthorization()
        {
            var client = this.CreateClient();
            client.DefaultRequestHeaders.Add("Unauthorized-Test", "true");

            return client;
        }
    }
}
