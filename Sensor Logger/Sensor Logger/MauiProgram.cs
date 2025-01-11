using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using Sensor_Logger.ViewModels;
using Sensor_Logger.Views;
using Sensor_Logger.Services;
using Sensor_Logger.Controls.Views;

namespace Sensor_Logger
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>().ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            }).UseMauiCommunityToolkit();

            builder.Services.AddSingleton<LoginService>();
            builder.Services.AddSingleton<LoginViewModel>();
            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddSingleton<RegisterPage>();
            builder.Services.AddSingleton<MainPageViewModel>();
            builder.Services.AddSingleton<MainPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif
            return builder.Build();

        }
    }
}