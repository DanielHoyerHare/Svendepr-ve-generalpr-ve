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

    public double? Calories { get; set; }
    public double? Carbohydrates { get; set; }

    public double? Protein { get; set; }

    public double? Fat { get; set; }

    public string Name { get; set; }


    public ICommand SaveCommand => new Command(async () => await Save());

    private async Task Save()
    {
        ApiService apiService = new ApiService();
        Food goal = new Food()
        {
            name = Name,
            carbohydrates = Carbohydrates,
            protein = Protein,
            fat = Fat,
            calories = Calories,
            godkendt = false
        };
        await apiService.RegisterFoodAsync(goal);
    }
}
