using Calorie_Tracker.Models.ApiModels;
using Calorie_Tracker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Calorie_Tracker.ViewModel;

public partial class FoedeVareAddView
{
    // Properties for the food item details
    public double? Calories { get; set; }
    public double? Carbohydrates { get; set; }
    public double? Protein { get; set; }
    public double? Fat { get; set; }
    public string Name { get; set; }

    // Command to save the food item
    public ICommand SaveCommand => new Command(async () => await Save());

    // Method to save the food item asynchronously
    private async Task Save()
    {
        try
        {
            // Create an instance of ApiService
            ApiService apiService = new ApiService();

            // Create a new Food object with the provided details
            Food food = new Food()
            {
                name = Name,
                carbonhydrates = Carbohydrates,
                protein = Protein,
                fat = Fat,
                calories = Calories,
                godkendt = false // Assuming default value for approval status
            };

            // Call the API service method to register the food item
            await apiService.RegisterFoodAsync(food);
        }
        catch (Exception ex)
        {
            // Log and handle any exceptions that occur during the process
            Console.WriteLine($"Error saving food item: {ex.Message}");
            throw;
        }
    }
}
