using Calorie_Tracker.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calorie_Tracker.ViewModel;

public partial class FoedevareView : ObservableObject
{

    [RelayCommand]
    async Task Foedevare()
    {
        await Shell.Current.GoToAsync(nameof(Foedevare));
    }



}
