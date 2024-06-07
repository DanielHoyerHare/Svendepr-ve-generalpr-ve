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



}
