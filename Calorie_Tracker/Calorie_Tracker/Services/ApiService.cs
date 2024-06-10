using Calorie_Tracker.Models.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Calorie_Tracker.Services
{
    class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:3000/Api/");
        }

        public async Task<Bruger> getBrugerInformation(int id)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                return null;
            }

            return await _httpClient.GetFromJsonAsync<Bruger>($"query={id}");
        }

        public async Task<bool> RegisterUserAsync(Bruger bruger)
        {
            var json = JsonSerializer.Serialize(bruger);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("register", content);


            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> RegisterGoalAsync(Goal goal)
        {
            var json = JsonSerializer.Serialize(goal);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("register", content);


            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
