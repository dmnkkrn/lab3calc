using CommunityToolkit.Maui;
using labcalcgit.ViewModels;
using labcalcgit.Views;
using Microsoft.Extensions.Logging;


namespace labcalcgit
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            
            builder.Services.AddTransient<AppShell>();
            builder.Services.AddTransient<HomePage>();
            builder.Services.AddTransient<CalculatorViewModel>();

            return builder.Build();
        }
    }
}
