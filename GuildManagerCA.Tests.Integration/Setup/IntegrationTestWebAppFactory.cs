using GuildManagerCA.Infrastructure.Persistence;
using GuildManagerCA.Tests.Integration.Setup.Auth;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Respawn;
using System.Data.Common;
using Testcontainers.MsSql;

namespace GuildManagerCA.Tests.Integration.Setup
{
    public class IntegrationTestWebAppFactory : WebApplicationFactory<Program>, IAsyncLifetime
    {
        private readonly MsSqlContainer _container = new MsSqlBuilder()
            .Build();

        private DbConnection _dbConnection = default!;
        private Respawner _respawner = default!;

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

        public async Task ResetDatabaseAsync()
        {
            await _respawner.ResetAsync(_container.GetConnectionString());
        }

        public async Task InitializeAsync()
        {
            await _container.StartAsync();
            _dbConnection = new SqlConnection(_container.GetConnectionString());
            await InitializeRespawner();
        }

        private async Task InitializeRespawner()
        {
            await _dbConnection.OpenAsync();
            _respawner = await Respawner.CreateAsync(_dbConnection, new RespawnerOptions
            {
                DbAdapter = DbAdapter.SqlServer,
                SchemasToInclude = new[] { "dbo" }
            });
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
