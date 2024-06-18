

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
namespace Calorie_Tracker.ViewModel;

public partial class MainPageView : ObservableObject
{
    public MainPageView()
    {
        
    }
    // Command to navigate to the registration page.
    // Used for registering a new user.
    [RelayCommand]
    async Task RegisterBruger()
    {
        await Shell.Current.GoToAsync(nameof(RegisterBruger));
    }
    // Command to navigate to the login page.
    // Used for logging in an existing user.
    [RelayCommand]
    async Task Login()
    {
        await Shell.Current.GoToAsync(nameof(Login));
    }
    




}
