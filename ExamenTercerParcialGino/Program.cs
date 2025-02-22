using ExamenTercerParcialGino.Models;
using ExamenTercerParcialGino;
using Microsoft.EntityFrameworkCore;
using ExamenTercerParcialGino.Data;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Ropacontext>(options =>
options.UseMySql(builder.Configuration.GetConnectionString("inventariodiversoDataBase"),
new MySqlServerVersion(new Version(8, 0, 23))));//Reemplaza con tu version de MySQL si es que es diferente
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();