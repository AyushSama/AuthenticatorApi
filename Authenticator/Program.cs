using Authenticator.Application.BusinessInterfaces;
using Authenticator.Application.BusinessServices;
using Authenticator.Application.LoginAttemptService;
using Authenticator.Core;
using Authenticator.CustomActionFilters;
using Authenticator.Data.Repositories;
using Authenticator.Data.RepositryInterfaces;
using Authenticator.TokenHandler;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // Define a security scheme for the Authorization header
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter 'Bearer' [space] and then your token",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    // Add security requirement
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IAdminMasterUserRepo, AdminMasterUserRepo>();
builder.Services.AddScoped<IAdminMasterUserService, AdminMasterUserService>();

builder.Services.AddScoped<IActivatorMenuMasterRepo, ActivatorMenuMasterRepo>();
builder.Services.AddScoped<IActivatorMenuMasterService, ActivatorMenuMasterService>();

builder.Services.AddScoped<IUserAuthenticatorService, UserAuthenticatorService>();
builder.Services.AddScoped<ILoginHistoryAuthenticatorService, LoginHistoryAuthenticatorService>();
builder.Services.AddSingleton<FailedLoginAttemptsService>();

builder.Services.AddScoped<HandleToken>();
builder.Services.AddScoped<Authenticate>();


// Configure JWT authentication
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var key = jwtSettings.GetValue<string>("Key");


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

builder.Services.AddDbContextPool<InboxContext>(options =>
    options.UseSqlServer("server=172.16.1.52;uid=ttarizwi;pwd=2024@RizwiDev;database=ttadb;Min Pool Size=5;Max Pool Size=500;TrustServerCertificate=True;MultipleActiveResultSets=True;", sqloptions =>
    {
        sqloptions.CommandTimeout(5);
    }));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAngularApp");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
