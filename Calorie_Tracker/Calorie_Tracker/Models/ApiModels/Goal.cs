using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Calorie_Tracker.Models.ApiModels;

class Goal
{
    [JsonPropertyName("startDate")]
    public DateTime? startDate { get; set; }  

    [JsonPropertyName("calorieGoal")]
    public double? calorieGoal { get; set; }  

    [JsonPropertyName("carbonhydratesGoal")]
    public double? carbohydratesGoal { get; set; } 

    [JsonPropertyName("proteinGoal")]
    public double? proteinGoal { get; set; }  

    [JsonPropertyName("fatGoal")]
    public double? fatGoal { get; set; }  

    [JsonPropertyName("user")]
    public string userId { get; set; }  
}
