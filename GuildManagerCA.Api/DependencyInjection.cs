using GuildManagerCA.Api.Common.Errors;
using GuildManagerCA.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace GuildManagerCA.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddSingleton<ProblemDetailsFactory, CustomProblemDetailsFactory>();
            services.AddMappings();

            return services;
        }
    }
}
