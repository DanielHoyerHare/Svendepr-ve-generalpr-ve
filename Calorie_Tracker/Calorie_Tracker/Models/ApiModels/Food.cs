using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Calorie_Tracker.Models.ApiModels;

class Food
{
    [JsonPropertyName("barcode")]
    public string barcode { get; set; }  

    [JsonPropertyName("name")]
    public string name { get; set; }  

    [JsonPropertyName("godkendt")]
    public bool? godkendt { get; set; }  

    [JsonPropertyName("calories")]
    public double? calories { get; set; }  

    [JsonPropertyName("carbonhydrates")]
    public double? carbohydrates { get; set; }  

    [JsonPropertyName("protein")]
    public double? protein { get; set; }  

    [JsonPropertyName("fat")]
    public double? fat{ get; set;}
}