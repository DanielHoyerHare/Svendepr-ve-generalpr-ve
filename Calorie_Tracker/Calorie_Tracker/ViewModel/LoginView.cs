
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Calorie_Tracker.ViewModel;

public partial class LoginView : ObservableObject
{


    [RelayCommand]
    async Task HomePage()
    {
        await Shell.Current.GoToAsync(nameof(HomePage));
    }


}
