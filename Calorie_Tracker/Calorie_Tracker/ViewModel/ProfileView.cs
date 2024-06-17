using Calorie_Tracker.Models.ApiModels;
using Calorie_Tracker.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.ApplicationModel.Communication;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Calorie_Tracker.ViewModel;

public partial class ProfileView : ObservableObject
{
    // Properties to store goal values for calories, carbohydrates, protein, and fat
    public double calorieGoal { get; set; }
    public double carboHydratesGoal { get; set; }
    public double proteinGoal { get; set; }
    public double fatGoal { get; set; }

    // Property to store the user ID
    public int userId { get; set; }

    // Command to save the goals, binding it to a method that performs the save action
    public ICommand SaveCommand => new Command(async () => await Save());

    // Method to save the goals using the ApiService
    private async Task Save()
    {
        // Create an instance of ApiService
        ApiService apiService = new ApiService();

        // Create a Goal object and set its properties with the current values
        Goal goal = new Goal()
        {
            startDate = DateTime.Now, // Set the start date to the current date and time
            calorieGoal = calorieGoal,
            carbohydratesGoal = carboHydratesGoal,
            proteinGoal = proteinGoal,
            fatGoal = fatGoal
        };

        // Call the RegisterGoalAsync method of ApiService to save the goal
        await apiService.RegisterGoalAsync(goal);

        async Task HomePage()
        {
            await Shell.Current.GoToAsync(nameof(HomePage));
        }
    }
}
