using Calorie_Tracker.Models.ApiModels;
using Calorie_Tracker.Services;
using CommunityToolkit.Mvvm.ComponentModel;
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

    public double calorieGoal { get; set; }
    public double carboHydratesGoal { get; set; }

    public double proteinGoal { get; set; }

    public double fatGoal { get; set; }

    public int userId { get; set; }

    public ICommand SaveCommand => new Command(async () => await Save());

    private async Task Save()
    {
        ApiService apiService = new ApiService();
        Goal goal = new Goal()
        {
            startDate = DateTime.Now,
            calorieGoal = calorieGoal,
            carbohydratesGoal = carboHydratesGoal,
            proteinGoal = proteinGoal,
            fatGoal = fatGoal
        };
        await apiService.RegisterGoalAsync(goal);
    }

}
