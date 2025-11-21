using API;
using Application;
using Application.DI;
using FluentValidation;
using Presentation.Extensions;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddApplicationDependencyInjection()
    .AddDatabase()
    .AddValidatorsFromAssemblies(ApplicationLayerAssemblies.GetAssemblies());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapEndpoints();

app.Run();