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

    public FoedevareView()
    {
        LoadFoodList();
    }

    private ObservableCollection<Food> FilteredFood { get; set; } = new ObservableCollection<Food>();

    [RelayCommand]
    async Task FoedevareAdd()
    {
        await Shell.Current.GoToAsync(nameof(FoedevareAdd));
    }

    private async Task LoadFoodList()
    {
        try
        {
            ApiService apiService = new ApiService();
            var foods = await apiService.getFoodList();

            foreach (var food in foods)
            {

                FilteredFood.Add(food);

            }

        }
        catch (Exception)
        {

            throw;
        }
    }

}
