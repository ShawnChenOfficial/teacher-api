﻿using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using teacher_api.Domain.Configurations;
using teacher_api.Infrastructure.configurations.Auth;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSignalR();


builder.Services.AddMemoryCache();

// Add services to the container.
builder.Services.AddControllers();

builder.ConfigureOrigins()
       .ConfigureDatabase()
       .ConfigureAuth()
       .ConfigureMediatR()
       .ConfigureDependencies();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

