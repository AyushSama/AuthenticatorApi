using Authenticator.Application.BusinessInterfaces;
using Authenticator.Application.BusinessServices;
using Authenticator.Core;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IUserAuthenticatorService, UserAuthenticatorService>();
builder.Services.AddScoped<ILoginHistoryAuthenticatorService, LoginHistoryAuthenticatorService>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
