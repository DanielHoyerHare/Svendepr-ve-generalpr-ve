using Calorie_Tracker.Pages;
using Calorie_Tracker.ViewModel;
using Microsoft.Extensions.Logging;


namespace Calorie_Tracker
{
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainPageView>();

            builder.Services.AddSingleton<HomePage>();
            builder.Services.AddSingleton<HomePageView>();

            builder.Services.AddSingleton<Foedevare>();
            builder.Services.AddSingleton<FoedevareView>();

            builder.Services.AddTransient<RegisterBruger>();
            builder.Services.AddTransient<RegisterBrugerView>();

            builder.Services.AddTransient<Login>();
            builder.Services.AddTransient<LoginView>();

            return builder.Build();
        }
    }
}
