using GuildManagerCA.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Respawn;
using Respawn.Graph;

namespace GuildManagerCA.Tests.Integration.Setup
{
    [Collection("GM")]
    public abstract class BaseIntegrationTest :  IAsyncLifetime
    {
        private readonly IServiceScope _scope;
        protected readonly ISender _sender;
        //private readonly Func<Respawner, Task> _resetDatabase;
        private HttpClient _httpClient;
        private HttpClient _unauthorizedHttpClient;
        private string _connectionString;
        private Respawner _respawner = default!;

        public HttpClient HttpClient { get => _httpClient; private set => _httpClient = value; }
        public HttpClient UnauthorizedHttpClient { get => _unauthorizedHttpClient; private set => _unauthorizedHttpClient = value; }

        public BaseIntegrationTest(IntegrationTestWebAppFactory factory)
        {
            _unauthorizedHttpClient = factory.CreateClientWithoutAuthorization();
            _scope = factory.Services.CreateScope();
            _connectionString = factory.ContainerConnectionString;
            _sender = _scope.ServiceProvider.GetRequiredService<ISender>();
            _httpClient = factory.CreateClient();
            
        }

        public async Task InitializeAsync()
        {
            var dbContext = _scope.ServiceProvider.GetService<GuildManagerDbContext>();
            var pendingMigrations = dbContext.Database.GetPendingMigrations();
            if (pendingMigrations.Any())
            {
                await dbContext.Database.MigrateAsync();
            }

            _respawner = await Respawner.CreateAsync(_connectionString, new RespawnerOptions
            {
                TablesToInclude = new[]
                {
                new Table("dbo", "Specializations")
            },
                SchemasToInclude = new[] { "dbo" }
            });
        }

        public async Task DisposeAsync()
        {
            await _respawner.ResetAsync(_connectionString);
        }
    }
}
