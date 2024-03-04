
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Services;
using Services.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddNpgsql<BancoG4Context>(builder.Configuration.GetConnectionString("BancoConnection"));
//builder.Services.AddDbContext<BancoG4Context>();

builder.Services.AddDbContext<BancoG4Context>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("BancoConnection")));

// Service Layer
builder.Services.AddScoped<Services.Interface.IBancoService, Services.BancoService>();
builder.Services.AddScoped<Services.Interface.IClienteService, Services.ClienteService>();
builder.Services.AddScoped<Services.Interface.IClienteXCuentaService, Services.ClienteXCuentaService>();
builder.Services.AddScoped<Services.Interface.ICuentaService, Services.CuentaService>();
builder.Services.AddScoped<Services.Interface.IDireccionService,Services.DireccionService>();
builder.Services.AddScoped<Services.Interface.ILocalidadService, Services.LocalidadService>();
builder.Services.AddScoped<Services.Interface.IPaisService,Services.PaisService>();
builder.Services.AddScoped<Services.Interface.IProvinciaService, Services.ProvinciaService>();
builder.Services.AddScoped<Services.Interface.ITipoCuentaService, Services.TipoCuentaService>();
builder.Services.AddScoped<Services.Interface.ITipoTransaccionService, Services.TipoTransaccionService>();
builder.Services.AddScoped<Services.ITransaccionesService,Services.TransaccionesService>();



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
