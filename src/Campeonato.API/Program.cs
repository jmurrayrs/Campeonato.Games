using System.Reflection;
using AutoMapper;
using Campeonato.Application.Commands;
using Campeonato.Domain.Interfaces.Services;
using Campeonato.Domain.Services;
using MediatR;
using Notificator.Interfaces;
using Notificator.NotificationContextPattern;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<INotificationContext, NotificationContext>();
builder.Services.AddScoped<IWorldCupService, WorldCupService>();
builder.Services.AddScoped(typeof(IRequestHandler<GenerateWorldCupCommand, GenerateWorldCupCommandResult>), typeof(GenerateWorldCupCommandHandler));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var assembly = Assembly.Load("Campeonato.Application");

builder.Services.AddAutoMapper(assembly);

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblyContaining<Program>();
    cfg.Lifetime = ServiceLifetime.Scoped;
});

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

public partial class Program { }