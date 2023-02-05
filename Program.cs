global using Microsoft.EntityFrameworkCore;
global using SuperVet.Services;
using System.Data.Common;
using SuperVet.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var cs = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<VetContext>(opt => opt.UseNpgsql(cs));
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddTransient<DbInitializer>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Enable CORS
app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

//Resets data on API startup

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var initializer = services.GetRequiredService<DbInitializer>();
initializer.Run();


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();

app.Run();