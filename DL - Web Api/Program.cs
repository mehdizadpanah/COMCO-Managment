using DL___Web_Api.Data;
using DL___Web_Api.Services;
using DL___Web_Api.TokenAuthentication;

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
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
