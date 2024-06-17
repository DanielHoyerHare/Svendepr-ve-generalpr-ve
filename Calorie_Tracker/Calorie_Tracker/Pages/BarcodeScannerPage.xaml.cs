using Calorie_Tracker.ViewModel;

namespace Calorie_Tracker.Pages;

public partial class BarcodeScannerPage : ContentPage
{
	public BarcodeScannerPage(BarcodeScannerPageView vm)
	{
		InitializeComponent();
		BindingContext = vm;

		barcodeReader.Options = new ZXing.Net.Maui.BarcodeReaderOptions()
		{
			Formats = ZXing.Net.Maui.BarcodeFormat.UpcE,
			AutoRotate = true,
			Multiple = false
		};
	}

    private void barcodeReader_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
    {
		var first = e.Results.FirstOrDefault();
		if (first != null) return;

		Dispatcher.DispatchAsync(async () =>
		{
			await DisplayAlert("Barcode Detected", first.Value, "Ok");
		});

        Shell.Current.GoToAsync(nameof(FoedevareAdd));

    }
}