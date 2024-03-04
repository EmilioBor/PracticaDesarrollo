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


var connecionString = builder.Configuration.GetConnectionString("BrokerConnection");
builder.Services.AddDbContext<AutosBDContext>(options =>
    options.UseNpgsql(connecionString));


builder.Services.AddScoped<IAutosService, AutosService>();
builder.Services.AddScoped<ICocheraService, CocheraService>();

//var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var proveedor = builder.Services.BuildServiceProvider();
var configuracion = proveedor.GetRequiredService<IConfiguration>();
builder.Services.AddCors(options =>
{
     var frontendURL = configuracion.GetValue<string>("frontend_url");
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins(frontendURL)
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
                          //policy.WithOrigins("http://localhost:3000/", "http://localhost:3001/", "http://localhost:3000/Cochera")
                          //  .AllowAnyHeader()  // Permite todos los encabezados
                          //  .AllowAnyMethod();  // Permite todos los métodos HTTP
                     
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
