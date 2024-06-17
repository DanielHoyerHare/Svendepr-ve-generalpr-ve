using Calorie_Tracker.Models.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calorie_Tracker.Models.Responses;

public class DailyIntakeResponseList
{
    public List<DailyIntake> dailyIntake { get; set; }

}
