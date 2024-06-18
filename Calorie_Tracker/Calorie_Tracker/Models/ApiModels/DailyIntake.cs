using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Calorie_Tracker.Models.ApiModels;

public class DailyIntake
{
    [JsonPropertyName("date")]
    public DateTime? Date { get; set; }  

    [JsonPropertyName("userID")]
    public string UserID { get; set; }  

    [JsonPropertyName("foodID")]
    public string FoodID { get; set; }  

    [JsonPropertyName("weight")]
    public double? Weight { get; set; }  
}
