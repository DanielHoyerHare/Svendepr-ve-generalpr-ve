using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Calorie_Tracker.Models.ApiModels
{
    class Bruger
    {
        [JsonPropertyName("id")]
        public Bruger brugerId { get; set; }

    }
}
