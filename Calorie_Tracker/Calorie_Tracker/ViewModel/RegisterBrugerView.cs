using Calorie_Tracker.Models.ApiModels;
using Calorie_Tracker.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using System.Windows.Input;

namespace Calorie_Tracker.ViewModel;

public partial class RegisterBrugerView : ObservableObject, INotifyPropertyChanged
{
    // Property to store user details
    public Bruger bruger { get; } = new Bruger();

    // Constructor to initialize a new Bruger instance with properties set from the class properties
    public RegisterBrugerView()
    {
        Bruger bruger = new Bruger()
        {
            username = username,
            email = email,
            rolle = rolle,
            password = password,
            age = age,
            weight = weight,
            height = height,
            admin = false // Default admin value is false
        };
    }

    // Backing field for confirm password
    private string _confirmPassword;

    // Event handler for property changes
    public event PropertyChangedEventHandler PropertyChanged;

    // Properties for user details
    public string username { get; set; }
    public string email { get; set; }
    public string rolle { get; set; }
    public string password { get; set; }
    public int age { get; set; }
    public int weight { get; set; }
    public int height { get; set; }

    // Command to register the user, binding it to the RegisterAsync method
    public ICommand RegisterCommand => new Command(async () => await RegisterAsync());

    // Method to register the user using the ApiService
    private async Task RegisterAsync()
    {
        // Create an instance of ApiService
        ApiService apiService = new ApiService();

        // Set the properties of the bruger object with the current values
        bruger.username = username;
        bruger.email = email;
        bruger.rolle = "user"; // Default role is "user"
        bruger.password = password;
        bruger.age = age;
        bruger.weight = weight;
        bruger.height = height;

        // Call the RegisterUserAsync method of ApiService to register the user
        await apiService.RegisterUserAsync(bruger);
    }
}
