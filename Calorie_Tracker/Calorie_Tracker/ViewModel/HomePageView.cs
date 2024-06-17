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
    // Constructor that calls the LoadGoal method to initialize goal data
    public HomePageView()
    {
        LoadGoal();
    }

    // Command for navigating to the Foedevare page
    [RelayCommand]
    async Task Foedevare()
    {
        await Shell.Current.GoToAsync(nameof(Foedevare));
    }

    // Command for navigating to the Profile page
    [RelayCommand]
    async Task Profile()
    {
        await Shell.Current.GoToAsync(nameof(Profile));
    }

    // Backing field for the Goal property
    private Goal _goal;

    // Property for storing goal data, with notification support
    public Goal Goal
    {
        get => _goal;
        set => SetProperty(ref _goal, value);
    }

    private double? _dailyIntake;

    public double? CurrentIntake
    {
        get => _dailyIntake;
        set => SetProperty(ref _dailyIntake, value);
    }


    // Method to load the user's goal data from the API
    public async Task LoadGoal()
    {
        try
        {
            // Create an instance of ApiService
            ApiService apiService = new ApiService();

            // Retrieve the token and userId from secure storage
            var token = await SecureStorage.GetAsync("auth_token");
            var id = await SecureStorage.GetAsync("userId");

            // Get user information using the API service
            Goal = await apiService.GetUserGoalByIdAsync(token, id);

            var intake = await apiService.GetDailyIntakeAsync(token, id);

            if (intake != null) CurrentIntake = intake;


        }
        catch (Exception ex)
        {
            // Log any exception that occurs during the process
            Console.WriteLine($"Failed to load goal: {ex.Message}");
        }

        


    }
}
