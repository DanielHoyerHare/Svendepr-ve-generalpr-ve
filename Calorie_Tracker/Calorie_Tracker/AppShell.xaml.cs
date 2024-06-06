namespace Calorie_Tracker
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(RegisterBruger), typeof(RegisterBruger));
            Routing.RegisterRoute(nameof(Login), typeof(Login));
        }
    }
}
