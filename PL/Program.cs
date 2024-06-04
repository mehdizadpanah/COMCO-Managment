using System.Text.Encodings.Web;
using System.Text.Unicode;
using MudBlazor.Services;
using Microsoft.AspNetCore.Components.Authorization;
using SH.Service;
using Blazored.LocalStorage;
using MudBlazor;
using SH.Data.Validator;
using SH.Data.ViewModel;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using System.Diagnostics;



var builder = WebApplication.CreateBuilder(args);
//builder.Configuration.AddJsonFile("appsettings.json");


// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddHttpClient();

builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices(config =>
{

    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomCenter;

    config.SnackbarConfiguration.PreventDuplicates = false;
    config.SnackbarConfiguration.NewestOnTop = false;
    config.SnackbarConfiguration.ShowCloseIcon = true;
    config.SnackbarConfiguration.VisibleStateDuration = 10000;
    config.SnackbarConfiguration.HideTransitionDuration = 500;
    config.SnackbarConfiguration.ShowTransitionDuration = 500;
    config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
});
builder.Services.AddScoped<ApiService>();

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
//be remove
builder.Services.AddScoped<dataFile>();
builder.Services.AddScoped<CustomAuthenticationStateProvider>();
builder.Services.AddSingleton<HtmlEncoder>(
    HtmlEncoder.Create(allowedRanges: new[] { UnicodeRanges.BasicLatin,
        UnicodeRanges.Arabic }));

builder.Services.AddBlazoredLocalStorage();

var app =  builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();



app.UseAuthentication();
app.UseAuthorization();

//app.UseEndpoints(endpoints =>
{
    //endpoints.MapBlazorHub();
    //endpoints.MapFallbackToPage("/_Host");

    // Configure a route to read the default page from the shared project
    //endpoints.MapFallbackToPage("/shared-default", "/_content/SH/Pages/Index.razor");
    //});

    app.MapBlazorHub();
    app.MapFallbackToPage("/_Host");

    //set global variable
    GlobalSettings.ApiAddress = builder.Configuration.GetValue<string>("APPSerttings:ApiAddress");
    GlobalSettings.ApiPort = builder.Configuration.GetValue<int>("APPSerttings:ApiPort");





    app.Run();
}
