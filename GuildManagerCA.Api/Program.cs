using GuildManagerCA.Api.Errors;
using GuildManagerCA.Api.Filters;
using GuildManagerCA.Api.Middleware;
using GuildManagerCA.Application;
using GuildManagerCA.Application.Services.Authentication;
using GuildManagerCA.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

{
    builder.Services
        .RegisterApplication()
        .RegisterInfrastructure(builder.Configuration);

    //builder.Services.AddControllers( opts => opts.Filters.Add<ErrorHandlingFilterAttribute>());
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddSingleton<ProblemDetailsFactory, CustomProblemDetailsFactory>();
}


var app = builder.Build();
{
    //app.UseMiddleware<ErrorHandlingMiddleware>();
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();

    app.MapControllers();

    app.Run();
}

