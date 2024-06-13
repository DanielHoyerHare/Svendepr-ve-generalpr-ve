using Calorie_Tracker.ViewModel;

namespace Calorie_Tracker.Pages;

public partial class Foedevare : ContentPage
{
	public Foedevare(FoedevareView vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}