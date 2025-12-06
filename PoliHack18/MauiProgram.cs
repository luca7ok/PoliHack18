using Microsoft.Extensions.Logging;
using MudBlazor.Services;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using Npgsql;
using PoliHack18.Services;
namespace PoliHack18;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        using var stream = FileSystem.OpenAppPackageFileAsync("appsettings.json").Result;
        var config = new ConfigurationBuilder()
            .AddJsonStream(stream)
            .Build();
        builder.Configuration.AddConfiguration(config);
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts => { fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular"); });

        string connectionString = "Host=aws-1-eu-north-1.pooler.supabase.com;Username=postgres.gzjoktirnlbuqifncwyy;Password=HatzChelutz1234!_*;Database=postgres;Port=5432;Ssl Mode=Require;Trust Server Certificate=true";

        // ** 2. Initialize the static Database connection (NpgsqlDataSource) **
        try
        {
            Database.InitializareConexiune(connectionString);
            
        }
        catch (Exception ex)
        {
            
            Console.WriteLine($"Database initialization failed: {ex.Message}");
            
        }


        builder.Services.AddMauiBlazorWebView();
        builder.Services.AddMudServices();
        builder.Services.AddSingleton<Services.IFlightService, Services.FlightService>();
        builder.Services.AddSingleton<Services.IFlightService, Services.FlightService>();
        builder.Services.AddSingleton<Services.NavMenuHide>();
#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}