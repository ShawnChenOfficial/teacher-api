using System.Text.Json.Serialization;
using teacher_api.Application.Base.Common;
using teacher_api.Infrastructure.Startups.Common.Auth;
using teacher_api.Infrastructure.Startups.Common.Database;
using teacher_api.Infrastructure.Startups.Common.MediatR;
using teacher_api.Startups.Common.Origins;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSignalR();

builder.Services.AddMemoryCache();

// Add services to the container.
builder.Services.AddControllers(options => options.Filters.Add<ApiExceptionFilterAttribute>())
    .AddJsonOptions(builder =>
    {
        builder.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.ConfigureOrigins()
       .ConfigureDatabase()
       .ConfigureAuth()
       .ConfigureMediatR()
       .ConfigureDependencies();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseWebSockets();

app.UseCors("ALLOWSPECIFICORIGINS");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

