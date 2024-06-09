using DL___Web_Api.Data;
using DL___Web_Api.Repository;
using DL___Web_Api.Services;
using DL___Web_Api.TokenAuthentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

using ComcoMContext context = new ComcoMContext();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

  

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAccountService, AccountServices>();
builder.Services.AddSingleton<ITokenManager, TokenManager>();
builder.Services.AddDbContext<ComcoMContext>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddAutoMapper(typeof(IStartup));
builder.Services.AddControllersWithViews();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
