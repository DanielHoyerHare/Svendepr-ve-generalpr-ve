using Calorie_Tracker.Models.ApiModels;
using Calorie_Tracker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Calorie_Tracker.ViewModel;

public partial class FoedeVareAddView
{


    public ICommand SaveCommand => new Command(async () => await Save());

    private async Task Save()
    {
        ApiService apiService = new ApiService();
        //Food goal = new Food()
        //{
        //    StartDate = DateTime.Now,
        //    CalorieGoal = calorieGoal,
        //    CarbohydratesGoal = carboHydratesGoal,
        //    ProteinGoal = proteinGoal,
        //    FatGoal = fatGoal
        //};
        //await apiService.RegisterGoalAsync(goal);
    }
}
