using Calorie_Tracker.Models.ApiModels;
using Calorie_Tracker.Models.Responses;
using Calorie_Tracker.Pages;
using Calorie_Tracker.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calorie_Tracker.ViewModel;

public partial class FoedevareView : ObservableObject
{
    // Collection to hold filtered food items
    [ObservableProperty]  
    ObservableCollection<Food> filteredFoods;


    // Constructor to initialize the view model
    public FoedevareView()
    {
        // Initialize the collection

        FilteredFoods = new ObservableCollection<Food>();


        // Load the food list asynchronously
        LoadFoodList();
    }

    // Command to navigate to the FoedevareAdd page
    [RelayCommand]
    async Task FoedevareAdd()
    {
        await Shell.Current.GoToAsync(nameof(FoedevareAdd));
    }

    // Command to navigate to the BarcodeScannerPage
    [RelayCommand]
    async Task BarcodeScannerPage()
    {
        await Shell.Current.GoToAsync(nameof(BarcodeScannerPage));
    }

    // Method to load the list of food items
    private async Task LoadFoodList()
    {
        try
        {
            // Create an instance of ApiService
            ApiService apiService = new ApiService();

            // List to store food items retrieved from the API
            FoodListReponse foods = new FoodListReponse();

            // Uncomment and modify the following line to fetch food list from API
            var token = await SecureStorage.GetAsync("auth_token");
            foods = await apiService.getFoodList(token);



            foreach (var food in foods.Foods)
            {
                FilteredFoods.Add(food);
            }
        }
        catch (Exception ex)
        {
            // Log and throw any exceptions that occur during the process
            Console.WriteLine($"Error loading food list: {ex.Message}");
            throw;
        }
    }

    [RelayCommand]
    async Task AddToDaily(Food selectedFood)
    {
        // Show alert to ask for grams input
        string gramsInput = await Application.Current.MainPage.DisplayPromptAsync("Grams", "Enter grams:");

        if (string.IsNullOrWhiteSpace(gramsInput))
        {
            // Handle case where user cancels or inputs invalid data
            return;
        }

        if (!double.TryParse(gramsInput, out double grams))
        {
            // Handle case where input cannot be parsed to double
            await Application.Current.MainPage.DisplayAlert("Error", "Invalid input. Please enter a valid number.", "OK");
            return;
        }

        ApiService apiService = new ApiService();

        bool confirm = await apiService.CreateDailyIntakeAsync(selectedFood,gramsInput);

        Console.WriteLine(confirm);
        
    }

}
