using HRServicesAPI;
using HRServicesAPI.Data;
using HRServicesAPI.Mapper;
using HRServicesAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var appSettingsSection = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettingsSection);

var appSettings = appSettingsSection.Get<AppSettings>();
var key = Encoding.ASCII.GetBytes(appSettings.Secret);

builder.Services
    .AddControllers()
    .AddNewtonsoftJson(
        options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft
                .Json
                .ReferenceLoopHandling
                .Ignore
    );

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc(
        "HRServicesAPISpec",
        new Microsoft.OpenApi.Models.OpenApiInfo()
        {
            Title = "HR Service API",
            Version = "v1",
            Description = "HR Service API Documentation",
            Contact = new Microsoft.OpenApi.Models.OpenApiContact()
            {
                Name = "BTS",
                Email = "info@bts.id",
                Url = new Uri("https://bts.id")
            },
            License = new Microsoft.OpenApi.Models.OpenApiLicense()
            {
                Name = "MIT License",
                Url = new Uri("https://en.wikipedia.org/wiki/MIT_License")
            }
        }
    );

    options.AddSecurityDefinition(
        "Bearer",
        new OpenApiSecurityScheme
        {
            Description =
                @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                          Enter 'Bearer' [space] and then your token in the text input below.
                          \r\n\r\nExample: 'Bearer 12345abcdef'",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        }
    );

    options.AddSecurityRequirement(
        new OpenApiSecurityRequirement()
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    },
                    Scheme = "oauth2",
                    Name = "Bearer",
                    In = ParameterLocation.Header,
                },
                new List<string>()
            }
        }
    );
});

// Add CORS
var corsPolicy = "CorsPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: corsPolicy,
        builder =>
        {
            builder
                .WithOrigins("http://localhost:3000")
                .AllowAnyHeader()
                .WithMethods("GET", "POST", "PUT", "PATCH", "DELETE", "OPTIONS")
                .AllowCredentials();
        }
    );
});

builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
        };
    });

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(AppMapper));

// Add DbContext
builder.Services.AddDbContext<DatabaseContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Repository DI
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPositionRepository, PositionRepository>();

// Service DI
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPositionService, PositionService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/HRServicesAPISpec/swagger.json", "HR Services API");
        options.RoutePrefix = "";
    });
}

app.UseCors(corsPolicy);

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
