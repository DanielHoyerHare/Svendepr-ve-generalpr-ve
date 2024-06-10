using Calorie_Tracker.ViewModel;

namespace Calorie_Tracker;

public partial class HomePage : ContentPage
{
	public HomePage(HomePageView vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}