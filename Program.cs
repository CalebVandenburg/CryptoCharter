using CryptoCharter.CoinMarketCap;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
var urlToUse = builder.Configuration["CoinMarketCap:Debug"].ToString() == "true" ? builder.Configuration["CoinMarketCap:TestBaseURL"] : builder.Configuration["CoinMarketCap:BaseURL"];
builder.Services.AddSingleton<CMCManager>(new CMCManager(builder.Configuration["CoinMarketCap:APIKey"], urlToUse));

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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
