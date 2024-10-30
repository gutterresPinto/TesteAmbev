using Microsoft.EntityFrameworkCore;
using _123Vendas.Infra.Data;
using Microsoft.Extensions.DependencyInjection.Extensions;
using _123Vendas.Application;
using __123Vendas.Infra.Data.Respositories._123Vendas;
using _123Vendas.Infra.Data.Respositories._123Vendas;
using Serilog;
using Serilog.Events;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<AppVendasContext>(opt => 
    opt.UseInMemoryDatabase("TodoList"));

builder.Services.AddScoped<VendasApplication>();
builder.Services.AddScoped<ClientesApplication>();
builder.Services.AddScoped<FilialApplication>();
builder.Services.AddScoped<ProdutoApplication>();
builder.Services.AddScoped<VendasRepository>();
builder.Services.AddScoped<ItemRepository>();
builder.Services.AddScoped<ProdutoRepository>();
builder.Services.AddScoped<ClientesRepository>();
builder.Services.AddScoped<FilialRepository>();

builder.Host.UseSerilog((ctx, lc) => lc
    .WriteTo.Console(LogEventLevel.Information));

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
