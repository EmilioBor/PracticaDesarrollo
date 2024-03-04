

using Tp4_weapi.Data;
using Tp4_weapi.Data.Repositories;
using Tp4_webapi.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var posgretConfiguration = new Postgresqlconf(builder.Configuration.GetConnectionString("PostgreSQLConfiguration"));
builder.Services.AddSingleton(posgretConfiguration);

builder.Services.AddScoped<IAutoRepository, AutoRepository>();//agregamos otro servicio - pasamos por inyectamos la dependencia y por parametro vamos a estar mandando el contructor va a estar mandando el connection string

var proveedor = builder.Services.BuildServiceProvider();
var configuracion = proveedor.GetRequiredService<IConfiguration>();

builder.Services.AddCors(opciones =>
{
    var frontendURL = configuracion.GetValue<string>("frontend_url"); //acceso a mi app de react

    opciones.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins(frontendURL).AllowAnyMethod().AllowAnyHeader();
    });

});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseHttpsRedirection();

//agregamos
app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
