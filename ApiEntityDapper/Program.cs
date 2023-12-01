using ApiEntityDapper.API.Mappers;
using ApiEntityDapper.Application.Services;
using ApiEntityDapper.Domain.Interface.IRepositories;
using ApiEntityDapper.Domain.Interface.IServices;
using ApiEntityDapper.Infra;
using ApiEntityDapper.Infra.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton(typeof(EntityToViewModelMapping));
//builder.Services.AddTransient(typeof(IMovieRepository), typeof(MovieRepository));
//builder.Services.AddTransient(typeof(IMovieRepository), typeof(MovieDapperRepository));
//builder.Services.AddTransient(typeof(IStrategyContextRepository), typeof(StrategyContextRepository));
builder.Services.AddTransient(typeof(IMovieService), typeof(MovieService));

builder.Services.AddDbContext<ApiEntityContext>(option =>
        option.UseSqlServer(builder.Configuration.GetSection("DatabaseSetting:ConnectionString").Value));
builder.Services.AddTransient<ApiEntityContext>();

builder.Services.AddScoped<ApiDapperContext>();

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

