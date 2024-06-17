using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Calorie_Tracker.Models.ApiModels;

public class Food
{
    [JsonPropertyName("_id")]
    public string _id { get; set; }

    [JsonPropertyName("barcode")]
    public string barcode { get; set; }  

    [JsonPropertyName("name")]
    public string name { get; set; }  

    [JsonPropertyName("godkendt")]
    public bool? godkendt { get; set; }  

    [JsonPropertyName("calories")]
    public double? calories { get; set; }  

    [JsonPropertyName("carbonhydrates")]
    public double? carbonhydrates { get; set; }  

    [JsonPropertyName("protein")]
    public double? protein { get; set; }  

    [JsonPropertyName("fat")]
    public double? fat{ get; set;}
}