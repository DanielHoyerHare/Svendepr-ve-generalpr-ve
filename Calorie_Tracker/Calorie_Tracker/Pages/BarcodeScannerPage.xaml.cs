using Calorie_Tracker.ViewModel;

namespace Calorie_Tracker.Pages;

public partial class BarcodeScannerPage : ContentPage
{
	public BarcodeScannerPage(BarcodeScannerPageView vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}