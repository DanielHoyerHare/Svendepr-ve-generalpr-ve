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
    public DateTime? StartDate { get; set; }  

    [JsonPropertyName("calorieGoal")]
    public double? CalorieGoal { get; set; }  

    [JsonPropertyName("carbonhydratesGoal")]
    public double? CarbohydratesGoal { get; set; } 

    [JsonPropertyName("proteinGoal")]
    public double? ProteinGoal { get; set; }  

    [JsonPropertyName("fatGoal")]
    public double? FatGoal { get; set; }  

    [JsonPropertyName("user")]
    public string UserId { get; set; }  
}
