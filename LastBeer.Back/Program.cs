using LastBeer.Back.Data;
using LastBeer.Back.Repository.IRepository;
using LastBeer.Back.Repository;
using Microsoft.EntityFrameworkCore;
using LastBeer.Back.Mappers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING"));
});

//Agregar Repositorios
builder.Services.AddScoped<IUserRepository, UserRepository>();

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
