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

    public Bruger bruger { get; } = new Bruger();

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
            admin = false
        };
    }

    


    private string _confirmPassword;

    public event PropertyChangedEventHandler PropertyChanged;

    public string username { get; set; }
    public string email { get; set; }

    public string rolle { get; set; }

    public string password { get; set; }

    public int age { get; set; }

    public int weight { get; set; }

    public int height { get; set; }

    public ICommand RegisterCommand => new Command(async () => await RegisterAsync());

    private async Task RegisterAsync()
    {
        ApiService apiService = new ApiService();
        bruger.username = username;
        bruger.email = email;
        bruger.rolle = "user";
        bruger.password = password;
        bruger.age = age;
        bruger.weight = weight;
        bruger.height = height;
        await apiService.RegisterUserAsync(bruger);
    }

}


