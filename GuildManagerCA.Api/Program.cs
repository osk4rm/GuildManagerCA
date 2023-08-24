using GuildManagerCA.Application;
using GuildManagerCA.Application.Services.Authentication;
using GuildManagerCA.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

{
    builder.Services
        .RegisterApplication()
        .RegisterInfrastructure();

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}


var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.MapControllers();

    app.Run();
}

