using MediatR;

namespace GuildManagerCA.Tests.Integration.Setup
{
    public abstract class BaseIntegrationTest : IClassFixture<IntegrationTestWebAppFactory>, IAsyncLifetime
    {
        private readonly IServiceScope _scope;
        protected readonly ISender _sender;
        private readonly Func<Task> _resetDatabase;
        private HttpClient _httpClient;

        public HttpClient HttpClient { get => _httpClient; private set => _httpClient = value; }

        public BaseIntegrationTest(IntegrationTestWebAppFactory factory)
        {
            _scope = factory.Services.CreateScope();

            _sender = _scope.ServiceProvider.GetRequiredService<ISender>();
            _httpClient = factory.CreateClient();
            _resetDatabase = factory.ResetDatabaseAsync;
        }

        public Task InitializeAsync() => Task.CompletedTask;

        public async Task DisposeAsync()
        {
            await _resetDatabase();
        }
    }
}
