using GuildManagerCA.Api;
using GuildManagerCA.Application;
using GuildManagerCA.Infrastructure;
using GuildManagerCA.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

{
    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
}



var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetService<GuildManagerDbContext>();

    var pendingMigrations = dbContext.Database.GetPendingMigrations();
    if (pendingMigrations.Any())
    {
        dbContext.Database.Migrate();
    }

    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();

    app.Run();
}

public partial class Program { }

