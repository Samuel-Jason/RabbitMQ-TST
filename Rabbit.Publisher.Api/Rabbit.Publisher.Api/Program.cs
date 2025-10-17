using Rabbit.Repositories;
using Rabbit.Repositories.Interfaces;
using Rabbit.Services;
using Rabbit.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Servi�os b�sicos
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura��o do RabbitMQ
builder.Services.AddScoped<IRabbitMensagemRepository, RabbitMensagemRepository>();
builder.Services.AddScoped<IRabbitMensagemService, RabbitMensagemService>();

var app = builder.Build();

// Middleware b�sico
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();