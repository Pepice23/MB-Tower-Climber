using MB_Tower_Climber.Services;
using Microsoft.Extensions.Logging;

namespace MB_Tower_Climber;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddMauiBlazorWebView();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        builder.Services.AddScoped<GameService>();
        builder.Services.AddScoped<PlayerService>();
        builder.Services.AddScoped<MonsterService>();
        builder.Services.AddScoped<BattleService>();
        builder.Services.AddScoped<EquipmentService>();
        builder.Services.AddScoped<ShopService>();


        return builder.Build();
    }
}
