
using Calorie_Tracker.Models.ApiModels;
using Calorie_Tracker.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Calorie_Tracker.ViewModel;

public partial class LoginView : ObservableObject
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string Incorrect {  get; set; }

    [RelayCommand]
    async Task HomePage()
    {
        Bruger bruger = new Bruger();

        bruger.email = Email;
        bruger.password = Password;

        ApiService apiService = new ApiService();

        var token = await apiService.LoginAsync(Email, Password);

        var id = await apiService.GetUserInfoAsync(token, Email);

        if (token != null)
        {
            await SecureStorage.SetAsync("auth_token", token);

            await Shell.Current.GoToAsync(nameof(HomePage));
        }
        else
        {
            Incorrect = "Email or password is incorrect";
        }


    
    }


}