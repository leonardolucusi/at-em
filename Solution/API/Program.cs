using API;
using Application;
using Application.DI;
using FluentValidation;
using Infrastructure.DI;
using Presentation.Extensions;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services
    .AddDatabase()
    .AddInfrastructureDependencyInjection()
    .AddApplicationDependencyInjection()
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
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