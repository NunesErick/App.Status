using Microsoft.OpenApi.Models;
using App.Monitor.Domain.Interfaces;
using App.Monitor.Infrastructure.Data.Context.Interface;
using App.Monitor.Infrastructure.Data.Context.Repositories;
using App.Monitor.Infrastructure.Data.Interfaces;
using App.Monitor.Infrastructure.Data.Repositories;
using App.Monitor.Service.Interfaces;
using App.Monitor.Service.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "App Monitor API",
        Version = "v1",
        Description = "API de monitoramento da aplicação"
    });
});

builder.Services.AddSingleton<IMonitor, App.Monitor.Domain.Repositories.Monitor>();
builder.Services.AddSingleton<IMonitorDAO, MonitorDAO>();
builder.Services.AddSingleton<IMonitorService, MonitorService>();
builder.Services.AddSingleton<IConnFactory, ConnFactory>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.WithOrigins("xxxx", "xxxx") //Adicione aqui o link do frontend.
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "App Monitor API V1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseCors("CorsPolicy");
app.Run();
