

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
namespace Calorie_Tracker.ViewModel;

public partial class MainPageView : ObservableObject
{
    public MainPageView()
    {
        
    }

    [RelayCommand]
    async Task RegisterBruger()
    {
        await Shell.Current.GoToAsync(nameof(RegisterBruger));
    }
    [RelayCommand]
    async Task Login()
    {
        await Shell.Current.GoToAsync(nameof(Login));
    }
    




}
