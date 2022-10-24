using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Ecu911.Data;
using Ecu911.ResponseModels;
using Ecu911.Servicios;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor.Services;


var builder = WebApplication.CreateBuilder(args);

//StaticWebAssetsLoader.UseStaticWebAssets(builder.Environment, builder.Configuration);

builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PreventDuplicates = false;
    config.SnackbarConfiguration.NewestOnTop = true;
});

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddBlazoredSessionStorage();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

var jwtTokenConfig = builder.Configuration.GetSection("JwtTokenConfig").Get<JwtTokenModel>();
builder.Services.AddSingleton(jwtTokenConfig);
builder.Services.AddScoped<JwtTokenGenerator>();


builder.Services.AddMudServices();
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





var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();