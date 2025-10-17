using Rabbit.Repositories;
using Rabbit.Repositories.Interfaces;
using Rabbit.Services;
using Rabbit.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Serviços básicos
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuração do RabbitMQ
builder.Services.AddScoped<IRabbitMensagemRepository, RabbitMensagemRepository>();
builder.Services.AddScoped<IRabbitMensagemService, RabbitMensagemService>();

var app = builder.Build();

// Middleware básico
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();