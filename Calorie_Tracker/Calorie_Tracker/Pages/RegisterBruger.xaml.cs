using Calorie_Tracker.ViewModel;

namespace Calorie_Tracker;

public partial class RegisterBruger : ContentPage
{
	public RegisterBruger(RegisterBrugerView vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}