using MediatR;

namespace GuildManagerCA.Tests.Integration.Setup
{
    [Collection("GM")]
    public abstract class BaseIntegrationTest :  IAsyncLifetime
    {
        private readonly IServiceScope _scope;
        protected readonly ISender _sender;
        private readonly Func<Task> _resetDatabase;
        private HttpClient _httpClient;
        private HttpClient _unauthorizedHttpClient;

        public HttpClient HttpClient { get => _httpClient; private set => _httpClient = value; }
        public HttpClient UnauthorizedHttpClient { get => _unauthorizedHttpClient; private set => _unauthorizedHttpClient = value; }

        public BaseIntegrationTest(IntegrationTestWebAppFactory factory)
        {
            _scope = factory.Services.CreateScope();
            _sender = _scope.ServiceProvider.GetRequiredService<ISender>();
            _httpClient = factory.CreateClient();
            _unauthorizedHttpClient = factory.CreateClientWithoutAuthorization();
            _resetDatabase = factory.ResetDatabaseAsync;
        }

        public Task InitializeAsync() => Task.CompletedTask;

        public async Task DisposeAsync()
        {
            await _resetDatabase();
        }
    }
}
