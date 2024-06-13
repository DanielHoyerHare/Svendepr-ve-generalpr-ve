using Calorie_Tracker.ViewModel;

namespace Calorie_Tracker.Pages;

public partial class FoedevareAdd : ContentPage
{
	public FoedevareAdd(FoedeVareAddView vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
    public FoedevareAdd() : this(new FoedeVareAddView())
    {
    }

}