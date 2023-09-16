using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using SH.Data.Model;
using MudBlazor.Services;
using System.Threading.RateLimiting;
using Microsoft.AspNetCore.Components.Authorization;
using SH.Class;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddMudServices();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
//builder.Services.AddAuthentication()
//    .AddCookie(option =>
//    option.LoginPath = "/SH/Pages/Identity/Login");


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
