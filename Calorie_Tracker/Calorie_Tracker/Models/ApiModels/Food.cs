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
    public string Barcode { get; set; }  

    [JsonPropertyName("name")]
    public string Name { get; set; }  

    [JsonPropertyName("godkendt")]
    public bool? Godkendt { get; set; }  

    [JsonPropertyName("calories")]
    public double? Calories { get; set; }  

    [JsonPropertyName("carbonhydrates")]
    public double? Carbohydrates { get; set; }  

    [JsonPropertyName("protein")]
    public double? Protein { get; set; }  

    [JsonPropertyName("fat")]
    public double? Fat{ get; set;}
}