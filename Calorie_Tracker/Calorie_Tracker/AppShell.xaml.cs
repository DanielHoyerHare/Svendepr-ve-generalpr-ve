using Calorie_Tracker.Pages;

namespace Calorie_Tracker;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(RegisterBruger), typeof(RegisterBruger));
        Routing.RegisterRoute(nameof(Login), typeof(Login));
        Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
        Routing.RegisterRoute(nameof(Foedevare), typeof(Foedevare));
        Routing.RegisterRoute(nameof(Profile), typeof(Profile));
    }
}
