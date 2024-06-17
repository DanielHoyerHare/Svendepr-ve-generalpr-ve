using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Calorie_Tracker.Models.ApiModels;

public class Bruger
{
    [JsonPropertyName("userId")]
    public string Id { get; set; }
    [JsonPropertyName("token")]
    public string token { get; set; }

    [JsonPropertyName("username")]
    public string username { get; set; }


    [JsonPropertyName("email")]
    public string email { get; set; }

    [JsonPropertyName("rolle")]
    public string rolle { get; set; }

    [JsonPropertyName("password")]
    public string password { get; set; }

    [JsonPropertyName("age")]
    public int age { get; set; }

    [JsonPropertyName("weight")]
    public int weight { get; set; }

    [JsonPropertyName("height")]
    public int height { get; set; }

    [JsonPropertyName("admin")]
    public bool admin { get; set; }


}
