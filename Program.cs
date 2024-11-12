using MongoApiDemo.Models;
using MongoApiDemo.Services;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Configurar el servicio de MongoDBSettings usando la configuración de appsettings.json
builder.Services.Configure<MongoDBSettings>(
    builder.Configuration.GetSection("MongoDBSettings"));

// Registrar el servicio UserServices como un singleton
builder.Services.AddSingleton<UserServices>();

// Añadir soporte para controladores
builder.Services.AddControllers();

// Configurar Swagger para la documentación de API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar el pipeline HTTP para Swagger en modo de desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Mapeo de los controladores
app.MapControllers();

app.Run();
