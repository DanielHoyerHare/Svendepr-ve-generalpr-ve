using Calorie_Tracker.ViewModel;

namespace Calorie_Tracker;

public partial class Login : ContentPage
{
	public Login(LoginView vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}