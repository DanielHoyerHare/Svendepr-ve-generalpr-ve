using Calorie_Tracker.ViewModel;

namespace Calorie_Tracker.Pages;

public partial class Profile : ContentPage
{
	public Profile(ProfileView vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}