using DotNetEnv;
using LibraryAPI.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;


var builder = WebApplication.CreateBuilder(args);

// Load environment variables
Env.Load();

var connectionString = Environment.GetEnvironmentVariable("EduLibraryConnection");
var authority = Environment.GetEnvironmentVariable("Jwt__Authority");
var audience = Environment.GetEnvironmentVariable("Jwt__Audience");



// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LibraryDbContext>(options =>
    options.UseSqlServer(connectionString));

// Repository & Service Registrations





// Authentication & Authorization
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = authority;
        options.Audience = audience;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidAudience = audience
        };
    });


builder.Services.AddAuthorization();

// Build the app
var app = builder.Build();

// Middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(options =>
    options.WithOrigins("http://localhost:4200")
           .AllowAnyMethod()
           .AllowAnyHeader());

//app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();