using Blazored.LocalStorage;

using Ecu911.Data;
using Ecu911.ResponseModels;
using Ecu911.Servicios;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PreventDuplicates = false;
    config.SnackbarConfiguration.NewestOnTop = true;
});
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddAuthorizationCore();
var jwtTokenConfig = builder.Configuration.GetSection("JwtTokenConfig").Get<JwtTokenModel>();
builder.Services.AddSingleton(jwtTokenConfig);
builder.Services.AddScoped<JwtTokenGenerator>();
builder.Services.AddBlazoredLocalStorage();

//controlador para DateTime?
//builder.Services.AddControllers()
//    .AddJsonOptions(options =>
//    {
//        options.JsonSerializerOptions.Converters.Add(new DateTime?JsonConverter());
//    });

builder.Services.AddHttpClient("api", options =>
{
    options.BaseAddress = new Uri(builder.Configuration.GetValue<string>("ApiUrl"));
});
builder.Services.AddTransient<ApiService>();


// builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //app.UseHsts();
}

//app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

//app.UseAuthentication();

app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();