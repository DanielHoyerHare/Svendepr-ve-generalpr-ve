using Calorie_Tracker.Models.ApiModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calorie_Tracker.Models.Responses;

public class DailyIntakeResponseList
{
    [JsonProperty("dailyIntakes")]
    public List<DailyIntake> dailyIntake { get; set; }

}
