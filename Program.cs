using Microsoft.EntityFrameworkCore;
using PlataformaEvaluacion.Models;
using PlataformaEvaluacion.Services;

var builder = WebApplication.CreateBuilder(args);

//add conection
builder.Services.AddDbContext<PlataformaevaluacionContext>(opciones => opciones.UseSqlServer(builder.Configuration.GetConnectionString("conexionSQL")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//ad services
builder.Services.AddScoped<EstudianteService>();
builder.Services.AddScoped<CursoService>();
builder.Services.AddScoped<IncricionesService>();
builder.Services.AddScoped<ExamenesServices>();
builder.Services.AddScoped<PreguntasService>();





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
