using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NzWalks.API.Data;
using NzWalks.API.Helper;
using NzWalks.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//we have three way of adding services to limit the scope of the created instance 
//scoped--the service called when every request is excuted
//transient--the service is called when this service is requested
//sigleton--the service is called throught the lifetime of the project

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDataProtection();
//inject the database context here to use everywhere
builder.Services.AddDbContext<NzWalksDbContext>(context => context.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));
builder.Services.AddScoped<IRegionRepository, RegionRepository>();  
builder.Services.AddScoped<IWalksRepository, WalksRepository>();  
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles)); 
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
