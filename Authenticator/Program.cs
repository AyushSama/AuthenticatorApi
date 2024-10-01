using Authenticator.Application.BusinessInterfaces;
using Authenticator.Application.BusinessServices;
using Authenticator.Application.LoginAttemptService;
using Authenticator.Core;
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

builder.Services.AddScoped<IUserAuthenticatorService, UserAuthenticatorService>();
builder.Services.AddScoped<ILoginHistoryAuthenticatorService, LoginHistoryAuthenticatorService>();
builder.Services.AddSingleton<FailedLoginAttemptsService>();

builder.Services.AddScoped<HandleToken>();


// Configure JWT authentication
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var key = jwtSettings.GetValue<string>("Key");

//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//})
//.AddJwtBearer(options =>
//{
//    options.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        ValidateLifetime = true,
//        ValidateIssuerSigningKey = true,
//        ValidIssuer = jwtSettings.GetValue<string>("Issuer"),
//        ValidAudience = jwtSettings.GetValue<string>("Audience"),
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
//    };
//});


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

builder.Services.AddDbContextPool<InboxContext>(options =>
    options.UseSqlServer("Server=172.16.1.90;uid=TTA2024;pwd=Rizvi@2024;database=RizviTTA;TrustServerCertificate=True;", sqloptions =>
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
