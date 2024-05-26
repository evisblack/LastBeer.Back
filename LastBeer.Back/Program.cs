using LastBeer.Back.Data;
using LastBeer.Back.Repository.IRepository;
using LastBeer.Back.Repository;
using Microsoft.EntityFrameworkCore;
using LastBeer.Back.Mappers;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    //options.UseSqlServer(builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING"));
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL"));
});

//Agregar Repositorios
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IFavouriteBarRepository, FavouriteBarRepository>();
builder.Services.AddScoped<IBarRepository, BarRepository>();
builder.Services.AddScoped<IVisitedBarRepository, VisitedBarRepository>();

//Agregar Automapper
builder.Services.AddAutoMapper(typeof(AppMapper));

var app = builder.Build();

app.UseSwagger();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
