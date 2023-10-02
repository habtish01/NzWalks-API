using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NzWalks.API.Data;
using NzWalks.API.Helper;
using NzWalks.API.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using System.Security.Cryptography.Xml;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//we have three way of adding services to limit the scope of the created instance 
//scoped--the service called when every request is excuted
//transient--the service is called when this service is requested
//sigleton--the service is called throught the lifetime of the project

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();  
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    {
    options.SwaggerDoc("v1",new OpenApiInfo { Title="NzWalks Api",Version="v1"});
        options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
        {
            Name="Authorization",
            In=ParameterLocation.Header,
            Type=SecuritySchemeType.ApiKey,
            Scheme=JwtBearerDefaults.AuthenticationScheme   
        });
        options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
              new OpenApiSecurityScheme
              {
                  Reference=new OpenApiReference
                  {
                      Id=JwtBearerDefaults.AuthenticationScheme,
                      Type=ReferenceType.SecurityScheme
                  },
                  Name=JwtBearerDefaults.AuthenticationScheme ,
                  Scheme="Oauth2",
                  In=ParameterLocation.Header

              },
              new List<string>()
            }
        });
    }
});


builder.Services.AddDataProtection();

//inject the database context here to use everywhere
builder.Services.AddDbContext<NzWalksDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));

builder.Services.AddDbContext<NzWalksAuthDbContext>(options=>
options.UseSqlServer(builder.Configuration.GetConnectionString("DbAuthConnection")));
builder.Services.AddScoped<IRegionRepository, RegionRepository>();  
builder.Services.AddScoped<IWalksRepository, WalksRepository>();  
builder.Services.AddScoped<ITokenRepository, TokenRepository>(); 
builder.Services.AddScoped<IImageRepository, LocalUploadImageRepository>();    
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

//Identity services
builder.Services.AddIdentityCore<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("NzWalks")
    .AddEntityFrameworkStores<NzWalksAuthDbContext>()
    .AddDefaultTokenProviders();

//configure some settings for password options
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 8;
    options.Password.RequiredUniqueChars = 1;

});
//authentication service

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => options
    .TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]))
    });   


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();    

app.UseAuthorization();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Images")),
    RequestPath = "/Images"
});

app.MapControllers();

app.Run();
