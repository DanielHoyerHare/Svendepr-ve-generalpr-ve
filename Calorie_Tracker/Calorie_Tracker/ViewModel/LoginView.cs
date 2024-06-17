
using Calorie_Tracker.Models.ApiModels;
using Calorie_Tracker.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Calorie_Tracker.ViewModel;

// The LoginView class is a ViewModel for handling user login functionality
public partial class LoginView : ObservableObject
{
    // Properties to store email, password, and error message
    public string Email { get; set; }
    public string Password { get; set; }
    public string Incorrect {  get; set; }

    // RelayCommand attribute is used to define the command for navigating to the HomePage
    [RelayCommand]
    async Task HomePage()
    {
        // Create an instance of ApiService to handle API calls
        ApiService apiService = new ApiService();

        // Call the LoginAsync method with the email and password to get the authentication token
        var token = await apiService.LoginAsync(Email, Password);

        // If a token is returned, navigate to the HomePage
        if (token != null)
        {
            await Shell.Current.GoToAsync(nameof(HomePage));
        }
        else
        {
            // If login fails, set the Incorrect property to display an error message
            Incorrect = "Email or password is incorrect";
        }


    
    }


}