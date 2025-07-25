﻿using Calorie_Tracker.Pages;
using Calorie_Tracker.ViewModel;
using Microsoft.Extensions.Logging;
using ZXing.Net.Maui.Controls;


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
                }).UseBarcodeReader(); // Enable barcode reader functionality


#if DEBUG
            builder.Logging.AddDebug();
#endif

            // Register Maui pages and their corresponding view models as services
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainPageView>();

            builder.Services.AddTransient<HomePage>();
            builder.Services.AddTransient<HomePageView>();

            builder.Services.AddTransient<Foedevare>();
            builder.Services.AddTransient<FoedevareView>();

            builder.Services.AddTransient<FoedevareAdd>();
            builder.Services.AddTransient<FoedeVareAddView>();

            builder.Services.AddTransient<Profile>();
            builder.Services.AddTransient<ProfileView>();

            builder.Services.AddTransient<BarcodeScannerPage>();
            builder.Services.AddTransient<BarcodeScannerPageView>();

            builder.Services.AddTransient<RegisterBruger>();
            builder.Services.AddTransient<RegisterBrugerView>();

            builder.Services.AddTransient<Login>();
            builder.Services.AddTransient<LoginView>();

            builder.Services.AddTransient<BarcodeScannerPage>();
            builder.Services.AddTransient<BarcodeScannerPageView>();

            return builder.Build();
        }
    }
}
