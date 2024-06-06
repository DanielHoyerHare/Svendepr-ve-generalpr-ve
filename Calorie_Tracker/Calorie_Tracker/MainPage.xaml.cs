using Calorie_Tracker.ViewModel;

namespace Calorie_Tracker
{
    public partial class MainPage : ContentPage
    {

        public MainPage(MainPageView vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }

    }

}
