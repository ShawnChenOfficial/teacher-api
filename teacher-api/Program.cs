﻿using teacher_api.Infrastructure.Startups.Common.Auth;
using teacher_api.Infrastructure.Startups.Common.Database;
using teacher_api.Infrastructure.Startups.Common.MediatR;
using teacher_api.Startups.Common.Origins;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSignalR();

builder.Services.AddMemoryCache();

// Add services to the container.
builder.Services.AddControllers();

builder.ConfigureOrigins()
       .ConfigureDatabase()
       .ConfigureAuth()
       .ConfigureMediatR();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

