using Calorie_Tracker.Models.ApiModels;
using Calorie_Tracker.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calorie_Tracker.ViewModel;

public partial class HomePageView : ObservableObject
{
    private ApiService _apiService;
    public HomePageView()
    {
        LoadGoal();
    }

    [RelayCommand]
    async Task Foedevare()
    {
        await Shell.Current.GoToAsync(nameof(Foedevare));
    }
    [RelayCommand]
    async Task Profile()
    {
        await Shell.Current.GoToAsync(nameof(Profile));
    }

    private Goal _goal;
    private Goal Goal
    {
        get => _goal;
        set => SetProperty(ref _goal, value);
    }

    public async Task LoadGoal()
    {
        try
        {

            var Token = await SecureStorage.GetAsync("auth_token");


            //_apiService.getBrugerInformation();

            //int userId = 1; 
            //Goal = await _apiService.GetGoalAsync(userId); 
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to load goal: {ex.Message}");
        }
    }

}
