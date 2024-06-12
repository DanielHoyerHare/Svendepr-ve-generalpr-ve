using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Calorie_Tracker.Models.ApiModels;

public class Bruger : INotifyPropertyChanged
{

    [JsonPropertyName("username")]
    public string Username;
    public string username
    {
        get { return Username; }
        set { Username = value; OnPropertyChanged(nameof(username));}
    }


    [JsonPropertyName("email")]
    string Email;
    public string email
    {
        get { return Email; }
        set { Email = value; OnPropertyChanged(nameof(email)); }
    }

    [JsonPropertyName("rolle")]
    public string rolle { get; set; }

    [JsonPropertyName("password")]
    string Password;
    public string password
    {
        get { return Password; }
        set { Password = value; OnPropertyChanged(nameof(password)); }
    }

    [JsonPropertyName("age")]
    int Age;
    public int age
    {
        get { return Age; }
        set { Age = value; OnPropertyChanged(nameof(age)); }
    }

    [JsonPropertyName("weight")]
    int Weight;
    public int weight
    {
        get { return Weight; }
        set { Weight = value; OnPropertyChanged(nameof(weight)); }
    }

    [JsonPropertyName("height")]
    int Height;
    public int height
    {
        get { return Height; }
        set { Height = value; OnPropertyChanged(nameof(height)); }
    }

    [JsonPropertyName("admin")]
    public bool admin { get; set; }

    public event PropertyChangedEventHandler PropertyChanged;
    void OnPropertyChanged(string name ) => 
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    public void SetProperty(string prop, string val)
    {

    }

}
