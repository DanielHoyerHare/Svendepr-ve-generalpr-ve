using Calorie_Tracker.Models.ApiModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
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
            _httpClient.BaseAddress = new Uri("http://172.20.10.3:5000/api/"); // HUSK AT SKIFT TIL DIN IPCONFIG IP ELLERS CONNECTION FAILURE!!
        }

        //public async Task<Bruger> getBrugerInformation(string token)
        //{

        //    return await _httpClient.GetFromJsonAsync<Bruger>("users");
        //}
        public async Task<List<Food>> getFoodList()
        {
            Console.WriteLine("Getting Foodlist");


            var foods = await _httpClient.GetFromJsonAsync<List<Food>>("foods");

            Console.WriteLine(foods);

            try
            {

                return foods;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP request failed: {ex.Message}");
                return null;
            }
        }

        public async Task<ObservableCollection<DailyIntake>> getDailyIntakeAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<ObservableCollection<DailyIntake>>($"query={id}");
            }
            catch (Exception)
            {

                throw;
            }
        }



        public async Task<bool> RegisterUserAsync(Bruger bruger)
        {
            try
            {
                var json = System.Text.Json.JsonSerializer.Serialize(bruger);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("auth/register", content);

                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP request failed: {ex.Message}");
                return false;
            }
        }

        public async Task<string> LoginAsync(string email, string password)
        {
            var user = new
            {
                email = email.Contains("@") ? email : null,
                password
            };

            var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("auth/login", content);


            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return result;
            }
            return null;

        }

        public async Task<Bruger> GetUserInfoAsync(string token,string email)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);


            var searchParams = new Dictionary<string, string>
            {
                { "searchTerm", email }
            };

            var requestUrl = new Uri(_httpClient.BaseAddress, $"users/search?{ToQueryString(searchParams)}");

            var response = await _httpClient.GetAsync(requestUrl);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var users = System.Text.Json.JsonSerializer.Deserialize<List<Bruger>>(json);
                return users?.Count > 0 ? users[0] : null;
            }

            return null;
        }

        public async Task<bool> RegisterFoodAsync(Food food)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(food);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("foods", content);


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
            var json = System.Text.Json.JsonSerializer.Serialize(goal);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("goals", content);


            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private string ToQueryString(Dictionary<string, string> parameters)
        {
            var keyValuePairs = new List<string>();
            foreach (var kvp in parameters)
            {
                keyValuePairs.Add($"{kvp.Key}={Uri.EscapeDataString(kvp.Value)}");
            }
            return string.Join("&", keyValuePairs);
        }
    }
}
