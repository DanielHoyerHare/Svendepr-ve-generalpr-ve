using Calorie_Tracker.Models.ApiModels;
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
    private ObservableCollection<Food> _filteredFood;
    private ObservableCollection<Food> FilteredFood
    {
        get { return _filteredFood; }
        set { SetProperty(ref _filteredFood, value); }
    }
    public FoedevareView()
    {
        FilteredFood = new ObservableCollection<Food>();

        LoadFoodList();
    }


    [RelayCommand]
    async Task FoedevareAdd()
    {
        await Shell.Current.GoToAsync(nameof(FoedevareAdd));
    }

    [RelayCommand]
    async Task BarcodeScannerPage()
    {
        await Shell.Current.GoToAsync(nameof(BarcodeScannerPage));
    }

    private async Task LoadFoodList()
    {
        try
        {
            ApiService apiService = new ApiService();

            List<Food> foods = new List<Food>();

            //var foods = await apiService.getFoodList();

            Food food1 = new Food();
            food1.calories = 1;
            food1.carbohydrates = 1;

            foods.Add(food1);

            foreach (var food in foods)
            {

                FilteredFood.Add(food);

            }

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading food list: {ex.Message}");
            throw;
        }
    }

}
